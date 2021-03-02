using CygSoft.Qik;
using NUnit.Framework;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class BatchCompilerTests
    {
        [Test]
        public void BatchCompiler_Generates_AutoInput()
        {
            BatchCompiler batchCompiler = new BatchCompiler();
            batchCompiler.CreateFieldInput("@Column1", "Column 1", "Description for Column 1");
            batchCompiler.CreateFieldInput("@Column2", "Column 1", "Description for Column 1");

            batchCompiler.Input("@Column1", "COL 1");
            batchCompiler.Input("@Column2", "COL 2");

            Generator generator = new Generator();
            string output = generator.Generate(batchCompiler, "@{Column1} is the first column, @{Column2} is the second column.");

            Assert.AreEqual("COL 1 is the first column, COL 2 is the second column.", output);

            Assert.AreEqual("Column 1", batchCompiler.GetSymbolInfo("@Column1").Title);
            Assert.AreEqual("Description for Column 1", batchCompiler.GetSymbolInfo("@Column1").Description);
        }
    }
}
