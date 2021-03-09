using CygSoft.Qik;
using NUnit.Framework;
using Qik.LanguageEngine.IntegrationTests.Helpers;
using System;

namespace Qik.LanguageEngine.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void ScriptExamples_InferPrimaryKeyFromPrimaryKeyOption_OutputsPrimaryKey()
        {
            string scriptText = FileHelpers.ReadText("InferPrimaryKey.qik");
            IInterpreter interpreter = new Intepreter();
            interpreter.Interpret(scriptText);

            interpreter.Input("@table", "MyTable");
            interpreter.Input("@userPrimaryKey", "CustomMyTableId");

            string table = interpreter.GetValueOfSymbol("@table");
            string userPrimaryKey = interpreter.GetValueOfSymbol("@userPrimaryKey");

            // there is no default, so primaryKeyOption1 = null, inferredKeyOption1 should be null?
            string primaryKeyOption1 = interpreter.GetValueOfSymbol("@primaryKeyOption");
            string inferredKeyOption1 = interpreter.GetValueOfSymbol("@inferredPrimaryKey");

            // made a selection: inferredKeyOption2 expected to be @userPrimaryKey.
            interpreter.Input("@primaryKeyOption", "CUSTOM");
            string primaryKeyOption2 = interpreter.GetValueOfSymbol("@primaryKeyOption");
            string inferredKeyOption2 = interpreter.GetValueOfSymbol("@inferredPrimaryKey");

            // made a selection: inferredKeyOption2 expected to be @table + "Id".
            interpreter.Input("@primaryKeyOption", "INFERRED");
            string primaryKeyOption3 = interpreter.GetValueOfSymbol("@primaryKeyOption");
            string inferredKeyOption3 = interpreter.GetValueOfSymbol("@inferredPrimaryKey");

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

        [Test]
        public void ScriptExamples_CreateMultilineScriptInExpression_OutputsCorrectly()
        {
            IInterpreter interpreter = new Intepreter();
            interpreter.Interpret(FileHelpers.ReadText("MultiLine.qik"));

            IGenerator generator = new Generator();
            string output = generator.Generate(interpreter, FileHelpers.ReadText("MultiLine.tpl"));

            Assert.AreEqual(FileHelpers.ReadText("MultiLine.out"), output);
        }

        [Test]
        public void ScriptExamples_CreateStoredProcOutput_BuildsCorrectSymbolsAndOutputValues()
        {
            IInterpreter interpreter = new Intepreter();
            interpreter.Interpret(FileHelpers.ReadText("StoredProc.qik"));

            IExpression[] expressions = interpreter.Expressions;
            IInputField[] inputFields = interpreter.InputFields;

            Assert.IsTrue(expressions.Length > 0);
            Assert.IsTrue(inputFields.Length > 0);

            var authorName = interpreter.GetValueOfSymbol("@authorName");
            var database = interpreter.GetValueOfSymbol("@database");
            var todayDate = interpreter.GetValueOfSymbol("@date");
            var authorCode = interpreter.GetValueOfSymbol("@authorCode");
            var description = interpreter.GetValueOfSymbol("@desc");
            var procTitle = interpreter.GetValueOfSymbol("@name");

            interpreter.Input("@name", "StoredProcName");
            interpreter.Input("@database", "MSDF_DW");
            interpreter.Input("@context", "BE");

            var procName = interpreter.GetValueOfSymbol("@procName");
            var fileTitle = interpreter.GetValueOfSymbol("@fileTitle");
            var filePath = interpreter.GetValueOfSymbol("@filePath");
            var database2 = interpreter.GetValueOfSymbol("@database");

            Assert.AreEqual("Rob Blake", authorName);
            Assert.AreEqual("MSDF_DM", database);
            Assert.AreEqual("0505c", authorCode);
            Assert.AreEqual(null, description);
            Assert.AreEqual(null, procTitle);
            Assert.AreEqual(DateTime.Now.ToString("dd/MM/yyyy"), todayDate);

            Assert.AreEqual("pRpt_StoredProcName", interpreter.GetValueOfSymbol("@procName"));
            Assert.AreEqual("pRpt_StoredProcName.sql", interpreter.GetValueOfSymbol("@fileTitle"));
            Assert.AreEqual(@"D:\Sandbox\MSDF\Code\SQLQueries\DataMartV2\Reports\pRpt_StoredProcName.sql", interpreter.GetValueOfSymbol("@filePath"));
            Assert.AreEqual("MSDF_DW", interpreter.GetValueOfSymbol("@database"));
        }

        [Test]
        public void ScriptExamples_OptionInput_Parsed_IsNotAPlaceholder()
        {
            var scriptText = FileHelpers.ReadText("OptionBox.qik");
            var interpreter = new Intepreter();
            interpreter.Interpret(scriptText);

            var inputField = interpreter.InputFields[0];
            Assert.IsFalse(inputField.IsPlaceholder);
        }
    }
}
