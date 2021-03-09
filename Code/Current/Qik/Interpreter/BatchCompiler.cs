using System;
using CygSoft.Qik.Antlr;

namespace CygSoft.Qik
{
    // TODO: Need BatchCompiler? If want this in future, then tag this branch and move on. Come back to it if necessary.
    public class BatchCompiler : IBatchCompiler
    {
        public event EventHandler BeforeInput;
        public event EventHandler AfterInput;
        public event EventHandler BeforeCompile;
        public event EventHandler AfterCompile;
        public event EventHandler<InterpretErrorEventArgs> CompileError;

        private readonly ISyntaxValidator syntaxValidator = null;
        private readonly IInterpreterEngine interpreterEngine = null;

        public bool HasErrors => syntaxValidator.HasErrors;
        public string[] Placeholders => interpreterEngine.Placeholders;
        public IExpression[] Expressions => interpreterEngine.Expressions;

        public BatchCompiler()
        {
            syntaxValidator = new SyntaxValidator();
            interpreterEngine = new InterpreterEngine();
        }

        public BatchCompiler(ISyntaxValidator syntaxValidator, IInterpreterEngine interpreterEngine)
        {
            this.syntaxValidator = syntaxValidator;
            this.interpreterEngine = interpreterEngine;
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
            interpreterEngine.CreateFieldInput(symbol, fieldName, description);

        public ISymbolInfo GetSymbolInfo(string symbol) => interpreterEngine.GetSymbolInfo(symbol);

        public ISymbolInfo[] GetSymbolInfoSet(string[] symbols) => interpreterEngine.GetSymbolInfoSet(symbols);

        public string GetValueOfPlaceholder(string placeholder) => interpreterEngine.GetValueOfPlaceholder(placeholder);

        public void Input(string symbol, string fieldValue)
        {
            interpreterEngine.BeforeInput += interpreterEngine_BeforeInput;
            interpreterEngine.AfterInput += interpreterEngine_AfterInput;

            interpreterEngine.Input(symbol, fieldValue);

            interpreterEngine.BeforeInput -= interpreterEngine_BeforeInput;
            interpreterEngine.AfterInput -= interpreterEngine_AfterInput;
        }

        private void CheckCompilation(string scriptText)
        {
            interpreterEngine.BeforeInterpret += Compiler_BeforeCompile;
            interpreterEngine.AfterInterpret += Compiler_AfterCompile;
            interpreterEngine.InterpretError += Compiler_CompileError;

            interpreterEngine.Interpret(scriptText);

            interpreterEngine.InterpretError -= Compiler_CompileError;
            interpreterEngine.BeforeInterpret -= Compiler_BeforeCompile;
            interpreterEngine.AfterInterpret -= Compiler_AfterCompile;
        }

        private void CheckSyntax(string scriptText)
        {
            syntaxValidator.CompileError += Compiler_CompileError;
            syntaxValidator.Validate(scriptText);
            syntaxValidator.CompileError -= Compiler_CompileError;
        }

        private void Compiler_AfterCompile(object sender, EventArgs e) => AfterCompile?.Invoke(this, e);

        private void Compiler_BeforeCompile(object sender, EventArgs e) => BeforeCompile?.Invoke(this, e);

        private void interpreterEngine_AfterInput(object sender, EventArgs e) => AfterInput?.Invoke(this, e);

        private void interpreterEngine_BeforeInput(object sender, EventArgs e) => BeforeInput?.Invoke(this, e);

        private void Compiler_CompileError(object sender, InterpretErrorEventArgs e) => CompileError?.Invoke(this, e);
    }
}
