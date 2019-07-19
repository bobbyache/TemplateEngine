//using CygSoft.Qik.LanguageEngine.Funcs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CygSoft.Qik.LanguageEngine
//{
//    public class FunctionFactory
//    {
//        public BaseFunction GetFunction(string functionIdentifier)
//        {
//            switch (funcIdentifier)
//            {
//                case "camelCase":
//                    CamelCaseFunction camelCaseFunc = new CamelCaseFunction(funcInfo, scopeTable, functionArguments);
//                    func = camelCaseFunc;
//                    break;
//                case "currentDate":
//                    CurrentDateFunction currentDateFunc = new CurrentDateFunction(funcInfo, scopeTable, functionArguments);
//                    func = currentDateFunc;
//                    break;
//                case "lowerCase":
//                    LowerCaseFunction lowerCaseFunc = new LowerCaseFunction(funcInfo, scopeTable, functionArguments);
//                    func = lowerCaseFunc;
//                    break;
//                case "upperCase":
//                    UpperCaseFunction upperCaseFunc = new UpperCaseFunction(funcInfo, scopeTable, functionArguments);
//                    func = upperCaseFunc;
//                    break;
//                case "properCase":
//                    ProperCaseFunction properCaseFunc = new ProperCaseFunction(funcInfo, scopeTable, functionArguments);
//                    func = properCaseFunc;
//                    break;
//                case "removeSpaces":
//                    RemoveSpacesFunction removeSpacesFunc = new RemoveSpacesFunction(funcInfo, scopeTable, functionArguments);
//                    func = removeSpacesFunc;
//                    break;
//                case "removePunctuation":
//                    RemovePunctuationFunction removePunctuationFunc = new RemovePunctuationFunction(funcInfo, scopeTable, functionArguments);
//                    func = removePunctuationFunc;
//                    break;
//                case "replace":
//                    ReplaceFunction replaceFunc = new ReplaceFunction(funcInfo, scopeTable, functionArguments);
//                    func = replaceFunc;
//                    break;
//                case "indentLine":
//                    IndentFunction indentFunc = new IndentFunction(funcInfo, scopeTable, functionArguments);
//                    func = indentFunc;
//                    break;
//                case "doubleQuotes": // for backward compatibility...
//                    DoubleQuoteFunction doubleQuoteFunction = new DoubleQuoteFunction(funcInfo, scopeTable, functionArguments);
//                    func = doubleQuoteFunction;
//                    break;
//                case "doubleQuote":
//                    DoubleQuoteFunction doubleQuoteFunction_Ex = new DoubleQuoteFunction(funcInfo, scopeTable, functionArguments);
//                    func = doubleQuoteFunction_Ex;
//                    break;
//                case "htmlEncode":
//                    HtmlEncodeFunction htmlEncodeFunction = new HtmlEncodeFunction(funcInfo, scopeTable, functionArguments);
//                    func = htmlEncodeFunction;
//                    break;

//                case "htmlDecode":
//                    HtmlDecodeFunction htmlDecodeFunction = new HtmlDecodeFunction(funcInfo, scopeTable, functionArguments);
//                    func = htmlDecodeFunction;
//                    break;
//                case "guid":
//                    GuidFunction guidFunction = new GuidFunction(funcInfo, scopeTable, functionArguments);
//                    func = guidFunction;
//                    break;
//                case "padLeft":
//                    PadLeftFunction padLeftFunction = new PadLeftFunction(funcInfo, scopeTable, functionArguments);
//                    func = padLeftFunction;
//                    break;
//                case "padRight":
//                    PadRightFunction padRightFunction = new PadRightFunction(funcInfo, scopeTable, functionArguments);
//                    func = padRightFunction;
//                    break;

//                default:
//                    throw new NotSupportedException(string.Format("Function \"{0}\" is not supported in this context.", funcIdentifier));
//            }
//        }
//    }
//}
