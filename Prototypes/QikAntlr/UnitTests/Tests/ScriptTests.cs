using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using CygSoft.Qik.LanguageEngine;
using CygSoft.Qik.LanguageEngine.Infrastructure;
using CygSoft.Qik.LanguageEngine.Scope;

namespace UnitTests.Tests
{
    [TestClass]
    [DeploymentItem(@"Files\Scripts\StoredProc.txt")]
    [DeploymentItem(@"Files\Scripts\StoredProc.tpl")]
    [DeploymentItem(@"Files\Scripts\MultiLine.txt")]
    [DeploymentItem(@"Files\Scripts\MultiLine.tpl")]
    [DeploymentItem(@"Files\Scripts\MultiLine.out")]
    [DeploymentItem(@"Files\Scripts\InferPK.txt")]
    [DeploymentItem(@"Files\Scripts\HtmlEncode.txt")]
    public class ScriptTests
    {
        [TestMethod]
        public void Script_InferPK()
        {
            string scriptText = File.ReadAllText("InferPK.txt");
            ICompiler compiler = new Compiler();
            compiler.Compile(scriptText);

            compiler.Input("@table", "MyTable");
            compiler.Input("@userPrimaryKey", "CustomMyTableId");

            string table = compiler.GetValueOfSymbol("@table");
            string userPrimaryKey = compiler.GetValueOfSymbol("@userPrimaryKey");

            // there is no default, so primaryKeyOption1 = null, inferredKeyOption1 should be null?
            string primaryKeyOption1 = compiler.GetValueOfSymbol("@primaryKeyOption");
            string inferredKeyOption1 = compiler.GetValueOfSymbol("@inferredPrimaryKey");

            // made a selection: inferredKeyOption2 expected to be @userPrimaryKey.
            compiler.Input("@primaryKeyOption", "CUSTOM");
            string primaryKeyOption2 = compiler.GetValueOfSymbol("@primaryKeyOption");
            string inferredKeyOption2 = compiler.GetValueOfSymbol("@inferredPrimaryKey");

            // made a selection: inferredKeyOption2 expected to be @table + "Id".
            compiler.Input("@primaryKeyOption", "INFERRED");
            string primaryKeyOption3 = compiler.GetValueOfSymbol("@primaryKeyOption");
            string inferredKeyOption3 = compiler.GetValueOfSymbol("@inferredPrimaryKey");

            // ensure both are null
            Assert.AreEqual(null, primaryKeyOption1);
            Assert.AreEqual(null, inferredKeyOption1);

            // ensure the custom primary key is used.
            Assert.AreEqual("CUSTOM", primaryKeyOption2);
            Assert.AreEqual("CustomMyTableId", inferredKeyOption2);

            // ensure the inferred primary key is used.
            Assert.AreEqual("INFERRED", primaryKeyOption3);
            Assert.AreEqual("MyTableId", inferredKeyOption3);
        }

        [TestMethod]
        public void Script_MultiLine()
        {
            string scriptText = File.ReadAllText("MultiLine.txt");
            string templateText = File.ReadAllText("MultiLine.tpl");
            string outputText = File.ReadAllText("MultiLine.out");

            ICompiler compiler = new Compiler();
            compiler.Compile(scriptText);

            IGenerator generator = new Generator();
            string output = generator.Generate(compiler, templateText);

            Assert.AreEqual(outputText, output);
        }

        [TestMethod]
        public void Script_StoredProc()
        {
            string scriptText = File.ReadAllText("StoredProc.txt");
            string templateText = File.ReadAllText("StoredProc.tpl");

            ICompiler compiler = new Compiler();
            compiler.Compile(scriptText);

            IExpression[] expressions = compiler.Expressions;
            IInputField[] inputFields = compiler.InputFields;

            Assert.IsTrue(expressions.Length > 0);
            Assert.IsTrue(inputFields.Length > 0);

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

        [TestMethod]
        public void Script_HtmlEncodeDecode()
        {
            string scriptText = File.ReadAllText("HtmlEncode.txt");

            ICompiler compiler = new Compiler();
            compiler.Compile(scriptText);
            compiler.Input("@normalText", @"Hello 'World'");

            string encodedText = compiler.GetValueOfSymbol("@encodedText");
            string decodedText = compiler.GetValueOfSymbol("@decodedText");

            Assert.AreEqual(@"Hello &#39;World&#39;", encodedText);
            Assert.AreEqual(@"Hello 'World'", decodedText);
        }
    }
}
