//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Code\you\ANTLR\QikTemplate.g4 by ANTLR 4.9.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="QikTemplateParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public interface IQikTemplateListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.template"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTemplate([NotNull] QikTemplateParser.TemplateContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.template"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTemplate([NotNull] QikTemplateParser.TemplateContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.ctrlDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCtrlDecl([NotNull] QikTemplateParser.CtrlDeclContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.ctrlDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCtrlDecl([NotNull] QikTemplateParser.CtrlDeclContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.optionBox"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionBox([NotNull] QikTemplateParser.OptionBoxContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.optionBox"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionBox([NotNull] QikTemplateParser.OptionBoxContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.textBox"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTextBox([NotNull] QikTemplateParser.TextBoxContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.textBox"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTextBox([NotNull] QikTemplateParser.TextBoxContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.optionsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptionsBody([NotNull] QikTemplateParser.OptionsBodyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.optionsBody"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptionsBody([NotNull] QikTemplateParser.OptionsBodyContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.singleOption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingleOption([NotNull] QikTemplateParser.SingleOptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.singleOption"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingleOption([NotNull] QikTemplateParser.SingleOptionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.exprDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExprDecl([NotNull] QikTemplateParser.ExprDeclContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.exprDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExprDecl([NotNull] QikTemplateParser.ExprDeclContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.optExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptExpr([NotNull] QikTemplateParser.OptExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.optExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptExpr([NotNull] QikTemplateParser.OptExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.ifOptExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIfOptExpr([NotNull] QikTemplateParser.IfOptExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.ifOptExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIfOptExpr([NotNull] QikTemplateParser.IfOptExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.declArgs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclArgs([NotNull] QikTemplateParser.DeclArgsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.declArgs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclArgs([NotNull] QikTemplateParser.DeclArgsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.declArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclArg([NotNull] QikTemplateParser.DeclArgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.declArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclArg([NotNull] QikTemplateParser.DeclArgContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpr([NotNull] QikTemplateParser.ExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpr([NotNull] QikTemplateParser.ExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.concatExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConcatExpr([NotNull] QikTemplateParser.ConcatExprContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.concatExpr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConcatExpr([NotNull] QikTemplateParser.ConcatExprContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFunc([NotNull] QikTemplateParser.FuncContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFunc([NotNull] QikTemplateParser.FuncContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="QikTemplateParser.funcArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFuncArg([NotNull] QikTemplateParser.FuncArgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="QikTemplateParser.funcArg"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFuncArg([NotNull] QikTemplateParser.FuncArgContext context);
}
