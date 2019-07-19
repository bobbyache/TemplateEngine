using System;
using System.IO;
using CSVParsing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVParser_Test
{
    [TestClass]
    [DeploymentItem(@"Files\cymbol_method.txt")]
    public class Test_CymbolMethod
    {
        [TestMethod]
        public void Test_MethodVariables()
        {
            string cymbolText = File.ReadAllText("cymbol_method.txt");
            CsvLoader loader = new CsvLoader();
            loader.CheckAllSymbols(cymbolText);
            
        }
    }
}
