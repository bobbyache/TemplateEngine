using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QikLanguageEngine.QikExpressions
{
    public class QikConcatenateFunction : QikFunction
    {
        private List<QikFunction> functions = new List<QikFunction>();

        public QikConcatenateFunction()
        {
            this.InputType = QikChildInputTypeEnum.Concatenation;
        }

        public override string Execute()
        {
            string result = "";
            foreach (QikFunction func in functions)
            {
                result += func.Execute();
            }
            return result;
        }

        public void AddFunction(QikFunction func)
        {
            functions.Add(func);
        }
    }
}
