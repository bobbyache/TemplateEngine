using CygSoft.Qik;
using NUnit.Framework;
using Moq;

namespace Qik.LanguageEngine.UnitTests
{
    [TestFixture]
    class CompilerTests
    {
        [Test]
        public void Should_Validate_Script()
        {
            var syntaxValidatorMock = new Mock<ISyntaxValidator>();
            var compileEngineMock = new Mock<ICompileEngine>();

            var compiler = new Compiler(syntaxValidatorMock.Object, compileEngineMock.Object);
            compiler.Compile("// Script text");

            syntaxValidatorMock.Verify(validator => validator.Validate(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Should_Interpret_Instructions_If_Syntax_Has_No_Errors()
        {
            var syntaxValidatorMock = new Mock<ISyntaxValidator>();
            syntaxValidatorMock.Setup(validator => validator.HasErrors).Returns(false);

            var compileEngineMock = new Mock<ICompileEngine>();

            var compiler = new Compiler(syntaxValidatorMock.Object, compileEngineMock.Object);
            compiler.Compile("// Script text has no errors");

            compileEngineMock.Verify(engine => engine.Compile(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Should_Not_Interpret_Instructions_If_Syntax_Has_Errors()
        {
            var syntaxValidatorMock = new Mock<ISyntaxValidator>();
            syntaxValidatorMock.Setup(validator => validator.HasErrors).Returns(true);

            var compileEngineMock = new Mock<ICompileEngine>();

            var compiler = new Compiler(syntaxValidatorMock.Object, compileEngineMock.Object);
            compiler.Compile("// Script text has errors");

            compileEngineMock.Verify(engine => engine.Compile(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Should_Fire_SyntaxErrorDetected_When_Interpreted_With_Incorrect_Title_Case()
        {
            bool wasCalled = false;
            Compiler compiler = new Compiler();
            compiler.CompileError += (s, e) => wasCalled = true;

            compiler.Compile("@dataType = text[title=\"5.Field Datatype)\", Description=\"The datatype for the field (column).\"];");

            Assert.IsTrue(wasCalled, "Expect that CompileError event is fired when a syntax error is discovered.");
        }

        [Test]
        public void Should_Fire_SyntaxErrorDetected_When_Interpreted_With_Incorrect_Description_Case()
        {
            bool wasCalled = false;
            Compiler compiler = new Compiler();
            compiler.CompileError += (s, e) =>
            {
                wasCalled = true;
            };

            compiler.Compile("@dataType = Text[title=\"5.Field Datatype)\", description=\"The datatype for the field (column).\"];");

            Assert.IsTrue(wasCalled, "Expect that CompileError event is fired when a syntax error is discovered.");
        }
    }
}
