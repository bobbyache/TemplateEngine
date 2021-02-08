using CygSoft.Qik.LanguageEngine.Funcs;
using CygSoft.Qik.LanguageEngine.Functions.Core;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using System.Collections.Generic;

namespace CygSoft.Qik.LanguageEngine
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
            IFunction func = null;

            switch (functionIdentifier)
            {
                case "camelCase":
                    CamelCaseFunction camelCaseFunc = new CamelCaseFunction(funcInfo, scopeTable, functionArguments);
                    func = camelCaseFunc;
                    break;
                case "currentDate":
                    CurrentDateFunction currentDateFunc = new CurrentDateFunction(funcInfo, scopeTable, functionArguments);
                    func = currentDateFunc;
                    break;
                case "lowerCase":
                    LowerCaseFunction lowerCaseFunc = new LowerCaseFunction(funcInfo, scopeTable, functionArguments);
                    func = lowerCaseFunc;
                    break;
                case "upperCase":
                    UpperCaseFunction upperCaseFunc = new UpperCaseFunction(funcInfo, scopeTable, functionArguments);
                    func = upperCaseFunc;
                    break;
                case "properCase":
                    ProperCaseFunction properCaseFunc = new ProperCaseFunction(funcInfo, scopeTable, functionArguments);
                    func = properCaseFunc;
                    break;
                case "removeSpaces":
                    RemoveSpacesFunction removeSpacesFunc = new RemoveSpacesFunction(funcInfo, scopeTable, functionArguments);
                    func = removeSpacesFunc;
                    break;
                case "removePunctuation":
                    RemovePunctuationFunction removePunctuationFunc = new RemovePunctuationFunction(funcInfo, scopeTable, functionArguments);
                    func = removePunctuationFunc;
                    break;
                case "replace":
                    ReplaceFunction replaceFunc = new ReplaceFunction(funcInfo, scopeTable, functionArguments);
                    func = replaceFunc;
                    break;
                case "indentLine":
                    IndentFunction indentFunc = new IndentFunction(funcInfo, scopeTable, functionArguments);
                    func = indentFunc;
                    break;
                case "doubleQuotes": // for backward compatibility...
                    DoubleQuoteFunction doubleQuoteFunction = new DoubleQuoteFunction(funcInfo, scopeTable, functionArguments);
                    func = doubleQuoteFunction;
                    break;
                case "doubleQuote":
                    DoubleQuoteFunction doubleQuoteFunction_Ex = new DoubleQuoteFunction(funcInfo, scopeTable, functionArguments);
                    func = doubleQuoteFunction_Ex;
                    break;
                case "htmlEncode":
                    HtmlEncodeFunction htmlEncodeFunction = new HtmlEncodeFunction(funcInfo, scopeTable, functionArguments);
                    func = htmlEncodeFunction;
                    break;

                case "htmlDecode":
                    HtmlDecodeFunction htmlDecodeFunction = new HtmlDecodeFunction(funcInfo, scopeTable, functionArguments);
                    func = htmlDecodeFunction;
                    break;
                case "guid":
                    GuidFunction guidFunction = new GuidFunction(funcInfo, scopeTable, functionArguments);
                    func = guidFunction;
                    break;
                case "padLeft":
                    PadLeftFunction padLeftFunction = new PadLeftFunction(funcInfo, scopeTable, functionArguments);
                    func = padLeftFunction;
                    break;
                case "padRight":
                    PadRightFunction padRightFunction = new PadRightFunction(funcInfo, scopeTable, functionArguments);
                    func = padRightFunction;
                    break;

                default:
                    throw new NotSupportedException(string.Format("Function \"{0}\" is not supported in this context.", functionIdentifier));
            }

            return func;
        }
    }
}
