using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QikLanguageEngine.QikControls;
using DynamicTypeDescriptor;

using Dyn = DynamicTypeDescriptor;
using Scm = System.ComponentModel;
using System.Drawing.Design;
using QikLanguageEngine.QikExpressions;

namespace QikLanguageEngine_Test
{
    // http://www.codeproject.com/Articles/415070/Dynamic-Type-Description-Framework-for-PropertyGri

    public partial class InputPropertyGrid : UserControl
    {
        private Dictionary<string, QikControl> optionsDictionary = null;
        private Dictionary<string, QikExpression> expressionDictionary = null;

        private const string CATEGORY_USER_INPUT = "1. User Input";
        private const string CATEGORY_EXPRESSION = "2. Expressions";

        public InputPropertyGrid()
        {
            InitializeComponent();
        }

        public void Reset(QikControl[] controlList, QikExpression[] expressionList)
        {
            optionsDictionary = new Dictionary<string, QikControl>();
            expressionDictionary = new Dictionary<string, QikExpression>();

            UserInputProperties properties = new UserInputProperties();
            Dyn.TypeDescriptor.IntallTypeDescriptor(properties);
            propertyGrid.SelectedObject = properties;

            foreach (QikControl ctrl in controlList)
            {
                if (ctrl is QikOptionBoxControl)
                {
                    CreateOptionsBox(ctrl as QikOptionBoxControl);   
                }
                else if (ctrl is QikCheckBoxControl)
                {
                    CreateCheckBox(ctrl as QikCheckBoxControl);
                }
                else if (ctrl is QikTextBoxControl)
                {
                    CreateTextBox(ctrl as QikTextBoxControl);
                }
                optionsDictionary.Add(ctrl.ControlId, ctrl);
            }


            foreach (QikExpression expression in expressionList)
            {
                CreateExpression(expression);
                expressionDictionary.Add(expression.Symbol, expression);
            }

            propertyGrid.Refresh();
        }

        private void CreateTextBox(QikTextBoxControl textBox)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);

            Dyn.PropertyDescriptor propertyDescriptor = new Dyn.PropertyDescriptor(propertyGrid.SelectedObject.GetType(),
                                                        textBox.ControlId,
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

        private void CreateCheckBox(QikCheckBoxControl checkBox)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);

            Dyn.PropertyDescriptor propertyDescriptor = new Dyn.PropertyDescriptor(propertyGrid.SelectedObject.GetType(),
                                                        checkBox.ControlId,
                                                        typeof(bool), bool.Parse(checkBox.DefaultValue),
                                                        new Scm.BrowsableAttribute(true),
                                                        new Scm.DisplayNameAttribute(checkBox.Title),
                                                        new Scm.DescriptionAttribute("Select true/false."),
                                                        new Scm.DefaultValueAttribute(bool.Parse(checkBox.DefaultValue))
                                                        );
            propertyDescriptor.Attributes.Add(new Scm.CategoryAttribute(CATEGORY_USER_INPUT), true);
            propertyDescriptor.Attributes.Add(new PropertyControlAttribute(ControlTypeEnum.CheckBox), true);

            propertyDescriptor.AddValueChanged(propertyGrid.SelectedObject, new EventHandler(this.InputPropertyChanged));
            typeDescriptor.GetProperties().Add(propertyDescriptor);
        }

        private void CreateOptionsBox(QikOptionBoxControl optionBox)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);
            Dyn.PropertyDescriptor propertyDescriptor = new Dyn.PropertyDescriptor(propertyGrid.SelectedObject.GetType(),
                                                        optionBox.ControlId,
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

        public void CreateExpression(QikExpression expression)
        {
            Dyn.TypeDescriptor typeDescriptor = Dyn.TypeDescriptor.GetTypeDescriptor(propertyGrid.SelectedObject);

            Dyn.PropertyDescriptor propertyDescriptor = new Dyn.PropertyDescriptor(propertyGrid.SelectedObject.GetType(),
                                                        expression.Symbol,
                                                        typeof(string), expression.Execute(),
                                                        //typeof(string), null,
                                                        new Scm.BrowsableAttribute(true),
                                                        new Scm.DisplayNameAttribute(expression.Title),
                                                        new Scm.DescriptionAttribute("Insert Text"),
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

        private void BuildOptions(Dyn.PropertyDescriptor pd, QikOptionBoxOption[] options)
        {
            pd.StandardValues.Clear();

            foreach (QikOptionBoxOption option in options)
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
                    string name = propertyDescriptor.Name;
                    object value = propertyDescriptor.GetValue(userInputProperties);

                    QikTextBoxControl textBox = optionsDictionary[name] as QikTextBoxControl;
                    textBox.SetCurrentValue(value != null ? value.ToString() : null);
                }
                else if (propertyControl != null && propertyControl.ControlType == ControlTypeEnum.OptionBox)
                {
                    string name = propertyDescriptor.Name;
                    object value = propertyDescriptor.GetValue(userInputProperties);

                    QikOptionBoxControl optionBox = optionsDictionary[name] as QikOptionBoxControl;
                    if (optionBox != null)
                    {
                        if (value != null)
                            optionBox.SelectOption(int.Parse(value.ToString()));
                        else
                            optionBox.ClearSelection(false);
                    }
                }
                else if (propertyControl != null && propertyControl.ControlType == ControlTypeEnum.CheckBox)
                {
                    string name = propertyDescriptor.Name;
                    string value = propertyDescriptor.GetValue(userInputProperties).ToString();

                    QikCheckBoxControl checkBox = optionsDictionary[name] as QikCheckBoxControl;
                    checkBox.SetCurrentValue(value);
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
                    string name = propertyDescriptor.Name;
                    string value = propertyDescriptor.GetValue(userInputProperties).ToString();

                    QikExpression expression = expressionDictionary[name] as QikExpression;
                    string newValue = expression.Execute();
                    propertyDescriptor.SetValue(userInputProperties, newValue);
                }
            }
        }
    }
}
