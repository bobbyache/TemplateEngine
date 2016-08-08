using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DynamicTypeDescriptor;

using Dyn = DynamicTypeDescriptor;
using Scm = System.ComponentModel;
using System.Drawing.Design;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine;

namespace QikLanguageEngine_Test
{
    // http://www.codeproject.com/Articles/415070/Dynamic-Type-Description-Framework-for-PropertyGri

    public partial class InputPropertyGrid : UserControl
    {
        public event EventHandler InputChanged;

        private const string CATEGORY_USER_INPUT = "1. User Input";
        private const string CATEGORY_EXPRESSION = "2. Expressions";

        private Compiler scriptCompiler;

        public InputPropertyGrid()
        {
            InitializeComponent();
        }

        public void Reset(Compiler compiler)
        {
            this.scriptCompiler = compiler;

            UserInputProperties properties = new UserInputProperties();
            Dyn.TypeDescriptor.IntallTypeDescriptor(properties);
            propertyGrid.SelectedObject = properties;

            foreach (IInputField field in compiler.InputFields)
            {
                if (field is ITextField)
                    CreateTextBox(field as ITextField);
                else if (field is IOptionsField)
                    CreateOptionsBox(field as IOptionsField);
            }

            foreach (IExpression expression in compiler.Expressions)
            {
                CreateExpression(expression);
            }

            propertyGrid.Refresh();
        }

        private void CreateTextBox(ITextField textBox)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);

            Dyn.PropertyDescriptor propertyDescriptor = new Dyn.PropertyDescriptor(propertyGrid.SelectedObject.GetType(),
                                                        textBox.Symbol,
                                                        typeof(string), textBox.DefaultValue,
                                                        new Scm.BrowsableAttribute(true),
                                                        new Scm.DisplayNameAttribute(textBox.Title),
                                                        new Scm.DescriptionAttribute("Insert Text"),
                                                        new Scm.DefaultValueAttribute(textBox.DefaultValue)
                                                        );
            propertyDescriptor.Attributes.Add(new Scm.CategoryAttribute(CATEGORY_USER_INPUT), true);
            propertyDescriptor.Attributes.Add(new PropertyControlAttribute(ControlTypeEnum.TextBox), true);
            propertyDescriptor.AddValueChanged(propertyGrid.SelectedObject, new EventHandler(this.InputPropertyChanged));

            typeDescriptor.GetProperties().Add(propertyDescriptor);
        }

        private void CreateOptionsBox(IOptionsField optionBox)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);
            Dyn.PropertyDescriptor propertyDescriptor = new Dyn.PropertyDescriptor(propertyGrid.SelectedObject.GetType(),
                                                        optionBox.Symbol,
                                                        typeof(int), optionBox.SelectedIndex,
                                                        new Scm.BrowsableAttribute(true),
                                                        new Scm.DisplayNameAttribute(optionBox.Title),
                                                        new Scm.DescriptionAttribute("Select an option."),
                                                        new Scm.DefaultValueAttribute(optionBox.SelectedIndex)
                                                        );
            propertyDescriptor.Attributes.Add(new Scm.CategoryAttribute(CATEGORY_USER_INPUT), true);
            propertyDescriptor.Attributes.Add(new PropertyControlAttribute(ControlTypeEnum.OptionBox), true);

            propertyDescriptor.Attributes.Add(new Scm.TypeConverterAttribute(typeof(Dyn.StandardValueConverter)), true);
            propertyDescriptor.Attributes.Add(new Scm.EditorAttribute(typeof(Dyn.StandardValueEditor), typeof(UITypeEditor)), true);

            BuildOptions(propertyDescriptor, optionBox.Options);

            propertyDescriptor.AddValueChanged(propertyGrid.SelectedObject, new EventHandler(this.InputPropertyChanged));
            typeDescriptor.GetProperties().Add(propertyDescriptor);
        }

        private void CreateExpression(IExpression expression)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);

            Dyn.PropertyDescriptor propertyDescriptor = new Dyn.PropertyDescriptor(propertyGrid.SelectedObject.GetType(),
                                                        expression.Symbol,
                                                        typeof(string), expression.Value,
                                                        //typeof(string), null,
                                                        new Scm.BrowsableAttribute(true),
                                                        new Scm.DisplayNameAttribute(expression.Title),
                                                        new Scm.DescriptionAttribute("Derived expression."),
                                                        new Scm.DefaultValueAttribute(null),
                                                        new Scm.ReadOnlyAttribute(true)
                                                        );
            propertyDescriptor.Attributes.Add(new Scm.CategoryAttribute(CATEGORY_EXPRESSION), true);
            propertyDescriptor.Attributes.Add(new PropertyControlAttribute(ControlTypeEnum.ExpressionBox), true);
            
            // If you don't want to raise  an "InputPropertyChanged" event for this property, then don't add a delegate.
            // Also, you'll be able to know exactly what property changed by having different handlers for different property
            // descriptors... good thing to know for the future !!!
            //propertyDescriptor.AddValueChanged(propertyGrid.SelectedObject, new EventHandler(this.InputPropertyChanged));

            typeDescriptor.GetProperties().Add(propertyDescriptor);
        }

        private void BuildOptions(Dyn.PropertyDescriptor pd, IOption[] options)
        {
            pd.StandardValues.Clear();

            foreach (IOption option in options)
            {
                Dyn.StandardValue sv = new Dyn.StandardValue(option.Index, option.Value);
                sv.Description = "Description of " + sv.DisplayName + ".";
                pd.StandardValues.Add(sv);
            }
        }

        private void InputPropertyChanged(object sender, EventArgs e)
        {
            UserInputProperties userInputProperties = sender as UserInputProperties;
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);
            PropertyDescriptorCollection propertyDescriptors = typeDescriptor.GetProperties();

            foreach (Dyn.PropertyDescriptor propertyDescriptor in propertyDescriptors)
            {
                PropertyControlAttribute propertyControl = propertyDescriptor.Attributes[typeof(PropertyControlAttribute)] as PropertyControlAttribute;
                if (propertyControl != null && propertyControl.ControlType == ControlTypeEnum.TextBox)
                {
                    string value = propertyDescriptor.GetValue(userInputProperties) != null ? propertyDescriptor.GetValue(userInputProperties).ToString() : null;
                    scriptCompiler.Input(propertyDescriptor.Name, value);
                }
                else if (propertyControl != null && propertyControl.ControlType == ControlTypeEnum.OptionBox)
                {
                    scriptCompiler.Input(propertyDescriptor.Name, propertyDescriptor.GetValue(userInputProperties).ToString());
                }
            }

            CalculateExpressions(userInputProperties);
            propertyGrid.Refresh();
        }

        private void CalculateExpressions(UserInputProperties userInputProperties)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);
            PropertyDescriptorCollection propertyDescriptors = typeDescriptor.GetProperties();

            foreach (Dyn.PropertyDescriptor propertyDescriptor in propertyDescriptors)
            {
                PropertyControlAttribute propertyControl = propertyDescriptor.Attributes[typeof(PropertyControlAttribute)] as PropertyControlAttribute;
                if (propertyControl != null && propertyControl.ControlType == ControlTypeEnum.ExpressionBox)
                {
                    string newValue = scriptCompiler.GetValueOfSymbol(propertyDescriptor.Name);
                    propertyDescriptor.SetValue(userInputProperties, newValue == null ? string.Empty : newValue);
                }
            }
        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (InputChanged != null)
                InputChanged(this, new EventArgs());
        }
    }
}
