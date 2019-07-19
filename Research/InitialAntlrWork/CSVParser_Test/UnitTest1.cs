using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CSVParsing;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSVParser_Test
{
    [TestClass]
    [DeploymentItem(@"Files\json_test.json")]
    [DeploymentItem(@"Files\json_test_xmlresult.xml")]
    [DeploymentItem(@"Files\cymbol.txt")]
    [DeploymentItem(@"Files\cymbol_verify.txt")]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_ParseCSV()
        {
            string hdrLine = "Details,Month,Amount";
            string line2 = "Mid Bonus,June,\"$2,000\"";
            string line3 = ",January,\"\"\"zippo\"\"\"";
            string line4 = "Total Bonuses,\"\",\"$5,000\"";

            string csvFile =
                hdrLine + "\n" +
                line2 + "\n" +
                line3 + "\n" +
                line4 + "\n";

            CsvLoader csvLoader = new CsvLoader();
            List<Dictionary<string, string>> rows = csvLoader.Load(csvFile);

            //Assert.IsTrue(File.Exists("json_test.json"));
            //Assert.IsTrue(File.Exists("json_test_xmlresult.xml"));
            Assert.IsTrue(rows.Count == 3);
        }

        [TestMethod]
        public void Test_JsonToXml()
        {
            string jsonFile = File.ReadAllText("json_test.json");
            string xmlFile = File.ReadAllText("json_test_xmlresult.xml");

            CsvLoader loader = new CsvLoader();
            string xml = loader.JsonToXml(jsonFile);

            //XElement resultXml = XElement.Parse(loader.JsonToXml(jsonFile));
            //XElement fileXml = XElement.Parse(xmlFile);
            //Assert.IsTrue(resultXml.Elements("logs").Nodes().GetEnumerator().
            //Assert.AreEqual(xmlFile.Trim(), x.Trim());
        }

        [TestMethod]
        public void Test_GetCymbolFunctions()
        {
            string cymbolText = File.ReadAllText("cymbol.txt");
            CsvLoader loader = new CsvLoader();
            loader.GetCymbolFunctions(cymbolText);
        }

        [TestMethod]
        public void Test_CymbolSymbolsVerify()
        {
            string cymbolText = File.ReadAllText("cymbol_verify.txt");
            CsvLoader loader = new CsvLoader();
            loader.CheckAllSymbols(cymbolText);
        }
    }
}
