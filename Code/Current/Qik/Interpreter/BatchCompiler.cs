using CygSoft.Qik.LanguageEngine.Infrastructure;
using System;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik.LanguageEngine
{
    public class BatchCompiler : IBatchCompiler
    {
        public event EventHandler BeforeInput;
        public event EventHandler AfterInput;
        public event EventHandler BeforeCompile;
        public event EventHandler AfterCompile;
        public event EventHandler<CompileErrorEventArgs> CompileError;

        private readonly ISyntaxValidator syntaxValidator = null;
        private readonly ICompileEngine compileEngine = null;

        public bool HasErrors => syntaxValidator.HasErrors;
        public string[] Placeholders => compileEngine.Placeholders;
        public IExpression[] Expressions => compileEngine.Expressions;

        public BatchCompiler()
        {
            syntaxValidator = new SyntaxValidator();
            compileEngine = new CompileEngine();
        }

        public BatchCompiler(ISyntaxValidator syntaxValidator, ICompileEngine compileEngine)
        {
            this.syntaxValidator = syntaxValidator;
            this.compileEngine = compileEngine;
        }

        public void Compile(string scriptText)
        {
            CheckSyntax(scriptText);
            if (!syntaxValidator.HasErrors)
            {
                CheckCompilation(scriptText);
            }
        }

        public string SymbolFromField(string fieldName) => "@" + fieldName;

        public void CreateFieldInput(string symbol, string fieldName, string description) => 
            compileEngine.CreateFieldInput(symbol, fieldName, description);

        public ISymbolInfo GetSymbolInfo(string symbol) => compileEngine.GetSymbolInfo(symbol);

        public ISymbolInfo[] GetSymbolInfoSet(string[] symbols) => compileEngine.GetSymbolInfoSet(symbols);

        public string GetValueOfPlaceholder(string placeholder) => compileEngine.GetValueOfPlaceholder(placeholder);

        public void Input(string symbol, string fieldValue)
        {
            compileEngine.BeforeInput += CompileEngine_BeforeInput;
            compileEngine.AfterInput += CompileEngine_AfterInput;

            compileEngine.Input(symbol, fieldValue);

            compileEngine.BeforeInput -= CompileEngine_BeforeInput;
            compileEngine.AfterInput -= CompileEngine_AfterInput;
        }

        private void CheckCompilation(string scriptText)
        {
            compileEngine.BeforeCompile += Compiler_BeforeCompile;
            compileEngine.AfterCompile += Compiler_AfterCompile;
            compileEngine.CompileError += Compiler_CompileError;

            compileEngine.Compile(scriptText);

            compileEngine.CompileError -= Compiler_CompileError;
            compileEngine.BeforeCompile -= Compiler_BeforeCompile;
            compileEngine.AfterCompile -= Compiler_AfterCompile;
        }

        private void CheckSyntax(string scriptText)
        {
            syntaxValidator.CompileError += Compiler_CompileError;
            syntaxValidator.Validate(scriptText);
            syntaxValidator.CompileError -= Compiler_CompileError;
        }

        private void Compiler_AfterCompile(object sender, EventArgs e) => AfterCompile?.Invoke(this, e);

        private void Compiler_BeforeCompile(object sender, EventArgs e) => BeforeCompile?.Invoke(this, e);

        private void CompileEngine_AfterInput(object sender, EventArgs e) => AfterInput?.Invoke(this, e);

        private void CompileEngine_BeforeInput(object sender, EventArgs e) => BeforeInput?.Invoke(this, e);

        private void Compiler_CompileError(object sender, CompileErrorEventArgs e) => CompileError?.Invoke(this, e);
    }
}
