using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;

namespace CygSoft.Qik.Functions
{
    public class FunctionFactory
    {
        private readonly IGlobalTable scopeTable;

        public FunctionFactory(IGlobalTable scopeTable)
        {
            this.scopeTable = scopeTable;
        }

        public IFunction GetFunction(string functionIdentifier, IFuncInfo funcInfo, List<IFunction> functionArguments)
        {
            IFunction func;

            switch (functionIdentifier)
            {
                case "camelCase":
                    func = new CamelCaseFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "currentDate":
                    func = new CurrentDateFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "lowerCase":
                    func = new LowerCaseFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "upperCase":
                    func = new UpperCaseFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "properCase":
                    func = new ProperCaseFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "removeSpaces":
                    func = new RemoveSpacesFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "removePunctuation":
                    func = new RemovePunctuationFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "replace":
                    func = new ReplaceFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "indentLine":
                    func = new IndentFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "doubleQuotes": // for backward compatibility...
                    func = new DoubleQuoteFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "doubleQuote":
                    func = new DoubleQuoteFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "htmlEncode":
                    func = new HtmlEncodeFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "htmlDecode":
                    func = new HtmlDecodeFunction(funcInfo, scopeTable, functionArguments);
                    break;

                case "guid":
                    var guidFunction = new GuidFunction(funcInfo, scopeTable, functionArguments);
                    func = guidFunction;
                    break;
                case "padLeft":
                    func = new PadLeftFunction(funcInfo, scopeTable, functionArguments);
                    break;
                case "padRight":
                    func = new PadRightFunction(funcInfo, scopeTable, functionArguments);
                    break;

                default:
                    func = null;
                    break;
            }

            if (func == null)
                throw new NotSupportedException(string.Format("Function \"{0}\" is not supported in this context.", functionIdentifier));

            return func;
        }
    }
}
