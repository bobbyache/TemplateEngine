using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Infrastructure;

namespace UnitTests.Tests
{
    [TestClass]
    public class ScriptTests
    {
        [TestMethod]
        [DeploymentItem(@"Files\Scripts\StoredProc.txt")]
        [DeploymentItem(@"Files\Scripts\StoredProc.tpl")]
        public void StoredProc_Script ()
        {
            string scriptText = File.ReadAllText("StoredProc.txt");
            string templateText = File.ReadAllText("StoredProc.tpl");

            ICompiler compiler = new Compiler();
            compiler.Compile(scriptText);

            IExpression[] expressions = compiler.Expressions;
            IInputField[] inputFields = compiler.InputFields;

            string authorName = compiler.GetValueOfSymbol("@authorName");
            string database = compiler.GetValueOfSymbol("@database");
            string todayDate = compiler.GetValueOfSymbol("@date");
            string authorCode = compiler.GetValueOfSymbol("@authorCode");
            string description = compiler.GetValueOfSymbol("@desc");
            string procTitle = compiler.GetValueOfSymbol("@name");

            compiler.Input("@name", "StoredProcName");
            compiler.Input("@database", "MSDF_DW");
            compiler.Input("@context", "BE");
            string procName = compiler.GetValueOfSymbol("@procName");
            string fileTitle = compiler.GetValueOfSymbol("@fileTitle");
            string filePath = compiler.GetValueOfSymbol("@filePath");
            string database2 = compiler.GetValueOfSymbol("@database");

            Assert.AreEqual("Rob Blake", authorName);
            Assert.AreEqual("MSDF_DM", database);
            Assert.AreEqual("0505c", authorCode);
            Assert.AreEqual(null, description);
            Assert.AreEqual(null, procTitle);
            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), todayDate);

            Assert.AreEqual("pRpt_StoredProcName", procName);
            Assert.AreEqual("pRpt_StoredProcName.sql", fileTitle);
            Assert.AreEqual(@"D:\Sandbox\MSDF\Code\SQLQueries\DataMartV2\Reports\pRpt_StoredProcName.sql", filePath);
            Assert.AreEqual("MSDF_DW", database2);
        }
    }
}
