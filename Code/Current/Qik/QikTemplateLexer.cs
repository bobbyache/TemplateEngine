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

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.1")]
[System.CLSCompliant(false)]
public partial class QikTemplateLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		CONST=18, STRING=19, IDENTIFIER=20, VARIABLE=21, FLOAT=22, INT=23, WS=24, 
		COMMENT=25, LINE_COMMENT=26;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"CONST", "STRING", "IDENTIFIER", "VARIABLE", "FLOAT", "INT", "LETTER", 
		"DIGIT", "WS", "COMMENT", "LINE_COMMENT"
	};


	public QikTemplateLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public QikTemplateLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'='", "'options'", "'['", "']'", "'{'", "'}'", "';'", "'text'", 
		"'return'", "','", "'option'", "'expression'", "'with'", "'if'", "'('", 
		"')'", "'+'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, "CONST", "STRING", "IDENTIFIER", "VARIABLE", 
		"FLOAT", "INT", "WS", "COMMENT", "LINE_COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "QikTemplate.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static QikTemplateLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '\x1C', '\xE4', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', '\x3', '\b', '\x3', '\b', 
		'\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', '\t', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', 
		'\x3', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', 
		'\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\f', '\x3', '\r', 
		'\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', 
		'\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\r', '\x3', '\xE', 
		'\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', 
		'\x3', '\xF', '\x3', '\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', 
		'\x3', '\x11', '\x3', '\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x3', '\x13', 
		'\x3', '\x13', '\x3', '\x13', '\x3', '\x13', '\x5', '\x13', '\x8D', '\n', 
		'\x13', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x14', '\a', 
		'\x14', '\x93', '\n', '\x14', '\f', '\x14', '\xE', '\x14', '\x96', '\v', 
		'\x14', '\x3', '\x14', '\x3', '\x14', '\x3', '\x15', '\x3', '\x15', '\x3', 
		'\x15', '\a', '\x15', '\x9D', '\n', '\x15', '\f', '\x15', '\xE', '\x15', 
		'\xA0', '\v', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', '\x16', '\x3', 
		'\x16', '\a', '\x16', '\xA6', '\n', '\x16', '\f', '\x16', '\xE', '\x16', 
		'\xA9', '\v', '\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\a', 
		'\x17', '\xAE', '\n', '\x17', '\f', '\x17', '\xE', '\x17', '\xB1', '\v', 
		'\x17', '\x3', '\x17', '\x3', '\x17', '\x5', '\x17', '\xB5', '\n', '\x17', 
		'\x3', '\x18', '\x6', '\x18', '\xB8', '\n', '\x18', '\r', '\x18', '\xE', 
		'\x18', '\xB9', '\x3', '\x19', '\x3', '\x19', '\x3', '\x1A', '\x3', '\x1A', 
		'\x3', '\x1B', '\x6', '\x1B', '\xC1', '\n', '\x1B', '\r', '\x1B', '\xE', 
		'\x1B', '\xC2', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1C', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1C', '\a', '\x1C', '\xCB', '\n', '\x1C', '\f', 
		'\x1C', '\xE', '\x1C', '\xCE', '\v', '\x1C', '\x3', '\x1C', '\x3', '\x1C', 
		'\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', 
		'\x3', '\x1D', '\x3', '\x1D', '\a', '\x1D', '\xD9', '\n', '\x1D', '\f', 
		'\x1D', '\xE', '\x1D', '\xDC', '\v', '\x1D', '\x3', '\x1D', '\x5', '\x1D', 
		'\xDF', '\n', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1D', '\x3', '\xCC', '\x2', '\x1E', '\x3', '\x3', '\x5', '\x4', '\a', 
		'\x5', '\t', '\x6', '\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', 
		'\x13', '\v', '\x15', '\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', 
		'\x1D', '\x10', '\x1F', '\x11', '!', '\x12', '#', '\x13', '%', '\x14', 
		'\'', '\x15', ')', '\x16', '+', '\x17', '-', '\x18', '/', '\x19', '\x31', 
		'\x2', '\x33', '\x2', '\x35', '\x1A', '\x37', '\x1B', '\x39', '\x1C', 
		'\x3', '\x2', '\a', '\x3', '\x2', '$', '$', '\x6', '\x2', '\x43', '\\', 
		'\x61', '\x61', '\x63', '|', '\x101', '\x101', '\x3', '\x2', '\x32', ';', 
		'\x5', '\x2', '\v', '\f', '\xE', '\xF', '\"', '\"', '\x4', '\x2', '\f', 
		'\f', '\xF', '\xF', '\x2', '\xF0', '\x2', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x5', '\x3', '\x2', '\x2', '\x2', '\x2', '\a', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\t', '\x3', '\x2', '\x2', '\x2', '\x2', '\v', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\r', '\x3', '\x2', '\x2', '\x2', '\x2', '\xF', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x13', '\x3', '\x2', '\x2', '\x2', '\x2', '\x15', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x17', '\x3', '\x2', '\x2', '\x2', '\x2', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '!', '\x3', '\x2', '\x2', '\x2', '\x2', '#', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '%', '\x3', '\x2', '\x2', '\x2', '\x2', '\'', 
		'\x3', '\x2', '\x2', '\x2', '\x2', ')', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'+', '\x3', '\x2', '\x2', '\x2', '\x2', '-', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '/', '\x3', '\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', 
		'\x2', '\x2', '\x2', '\x3', ';', '\x3', '\x2', '\x2', '\x2', '\x5', '=', 
		'\x3', '\x2', '\x2', '\x2', '\a', '\x45', '\x3', '\x2', '\x2', '\x2', 
		'\t', 'G', '\x3', '\x2', '\x2', '\x2', '\v', 'I', '\x3', '\x2', '\x2', 
		'\x2', '\r', 'K', '\x3', '\x2', '\x2', '\x2', '\xF', 'M', '\x3', '\x2', 
		'\x2', '\x2', '\x11', 'O', '\x3', '\x2', '\x2', '\x2', '\x13', 'T', '\x3', 
		'\x2', '\x2', '\x2', '\x15', '[', '\x3', '\x2', '\x2', '\x2', '\x17', 
		']', '\x3', '\x2', '\x2', '\x2', '\x19', '\x64', '\x3', '\x2', '\x2', 
		'\x2', '\x1B', 'o', '\x3', '\x2', '\x2', '\x2', '\x1D', 't', '\x3', '\x2', 
		'\x2', '\x2', '\x1F', 'w', '\x3', '\x2', '\x2', '\x2', '!', 'y', '\x3', 
		'\x2', '\x2', '\x2', '#', '{', '\x3', '\x2', '\x2', '\x2', '%', '\x8C', 
		'\x3', '\x2', '\x2', '\x2', '\'', '\x8E', '\x3', '\x2', '\x2', '\x2', 
		')', '\x99', '\x3', '\x2', '\x2', '\x2', '+', '\xA1', '\x3', '\x2', '\x2', 
		'\x2', '-', '\xB4', '\x3', '\x2', '\x2', '\x2', '/', '\xB7', '\x3', '\x2', 
		'\x2', '\x2', '\x31', '\xBB', '\x3', '\x2', '\x2', '\x2', '\x33', '\xBD', 
		'\x3', '\x2', '\x2', '\x2', '\x35', '\xC0', '\x3', '\x2', '\x2', '\x2', 
		'\x37', '\xC6', '\x3', '\x2', '\x2', '\x2', '\x39', '\xD4', '\x3', '\x2', 
		'\x2', '\x2', ';', '<', '\a', '?', '\x2', '\x2', '<', '\x4', '\x3', '\x2', 
		'\x2', '\x2', '=', '>', '\a', 'q', '\x2', '\x2', '>', '?', '\a', 'r', 
		'\x2', '\x2', '?', '@', '\a', 'v', '\x2', '\x2', '@', '\x41', '\a', 'k', 
		'\x2', '\x2', '\x41', '\x42', '\a', 'q', '\x2', '\x2', '\x42', '\x43', 
		'\a', 'p', '\x2', '\x2', '\x43', '\x44', '\a', 'u', '\x2', '\x2', '\x44', 
		'\x6', '\x3', '\x2', '\x2', '\x2', '\x45', '\x46', '\a', ']', '\x2', '\x2', 
		'\x46', '\b', '\x3', '\x2', '\x2', '\x2', 'G', 'H', '\a', '_', '\x2', 
		'\x2', 'H', '\n', '\x3', '\x2', '\x2', '\x2', 'I', 'J', '\a', '}', '\x2', 
		'\x2', 'J', '\f', '\x3', '\x2', '\x2', '\x2', 'K', 'L', '\a', '\x7F', 
		'\x2', '\x2', 'L', '\xE', '\x3', '\x2', '\x2', '\x2', 'M', 'N', '\a', 
		'=', '\x2', '\x2', 'N', '\x10', '\x3', '\x2', '\x2', '\x2', 'O', 'P', 
		'\a', 'v', '\x2', '\x2', 'P', 'Q', '\a', 'g', '\x2', '\x2', 'Q', 'R', 
		'\a', 'z', '\x2', '\x2', 'R', 'S', '\a', 'v', '\x2', '\x2', 'S', '\x12', 
		'\x3', '\x2', '\x2', '\x2', 'T', 'U', '\a', 't', '\x2', '\x2', 'U', 'V', 
		'\a', 'g', '\x2', '\x2', 'V', 'W', '\a', 'v', '\x2', '\x2', 'W', 'X', 
		'\a', 'w', '\x2', '\x2', 'X', 'Y', '\a', 't', '\x2', '\x2', 'Y', 'Z', 
		'\a', 'p', '\x2', '\x2', 'Z', '\x14', '\x3', '\x2', '\x2', '\x2', '[', 
		'\\', '\a', '.', '\x2', '\x2', '\\', '\x16', '\x3', '\x2', '\x2', '\x2', 
		']', '^', '\a', 'q', '\x2', '\x2', '^', '_', '\a', 'r', '\x2', '\x2', 
		'_', '`', '\a', 'v', '\x2', '\x2', '`', '\x61', '\a', 'k', '\x2', '\x2', 
		'\x61', '\x62', '\a', 'q', '\x2', '\x2', '\x62', '\x63', '\a', 'p', '\x2', 
		'\x2', '\x63', '\x18', '\x3', '\x2', '\x2', '\x2', '\x64', '\x65', '\a', 
		'g', '\x2', '\x2', '\x65', '\x66', '\a', 'z', '\x2', '\x2', '\x66', 'g', 
		'\a', 'r', '\x2', '\x2', 'g', 'h', '\a', 't', '\x2', '\x2', 'h', 'i', 
		'\a', 'g', '\x2', '\x2', 'i', 'j', '\a', 'u', '\x2', '\x2', 'j', 'k', 
		'\a', 'u', '\x2', '\x2', 'k', 'l', '\a', 'k', '\x2', '\x2', 'l', 'm', 
		'\a', 'q', '\x2', '\x2', 'm', 'n', '\a', 'p', '\x2', '\x2', 'n', '\x1A', 
		'\x3', '\x2', '\x2', '\x2', 'o', 'p', '\a', 'y', '\x2', '\x2', 'p', 'q', 
		'\a', 'k', '\x2', '\x2', 'q', 'r', '\a', 'v', '\x2', '\x2', 'r', 's', 
		'\a', 'j', '\x2', '\x2', 's', '\x1C', '\x3', '\x2', '\x2', '\x2', 't', 
		'u', '\a', 'k', '\x2', '\x2', 'u', 'v', '\a', 'h', '\x2', '\x2', 'v', 
		'\x1E', '\x3', '\x2', '\x2', '\x2', 'w', 'x', '\a', '*', '\x2', '\x2', 
		'x', ' ', '\x3', '\x2', '\x2', '\x2', 'y', 'z', '\a', '+', '\x2', '\x2', 
		'z', '\"', '\x3', '\x2', '\x2', '\x2', '{', '|', '\a', '-', '\x2', '\x2', 
		'|', '$', '\x3', '\x2', '\x2', '\x2', '}', '~', '\a', 'V', '\x2', '\x2', 
		'~', '\x7F', '\a', '\x43', '\x2', '\x2', '\x7F', '\x8D', '\a', '\x44', 
		'\x2', '\x2', '\x80', '\x81', '\a', 'U', '\x2', '\x2', '\x81', '\x82', 
		'\a', 'R', '\x2', '\x2', '\x82', '\x83', '\a', '\x43', '\x2', '\x2', '\x83', 
		'\x84', '\a', '\x45', '\x2', '\x2', '\x84', '\x8D', '\a', 'G', '\x2', 
		'\x2', '\x85', '\x86', '\a', 'P', '\x2', '\x2', '\x86', '\x87', '\a', 
		'G', '\x2', '\x2', '\x87', '\x88', '\a', 'Y', '\x2', '\x2', '\x88', '\x89', 
		'\a', 'N', '\x2', '\x2', '\x89', '\x8A', '\a', 'K', '\x2', '\x2', '\x8A', 
		'\x8B', '\a', 'P', '\x2', '\x2', '\x8B', '\x8D', '\a', 'G', '\x2', '\x2', 
		'\x8C', '}', '\x3', '\x2', '\x2', '\x2', '\x8C', '\x80', '\x3', '\x2', 
		'\x2', '\x2', '\x8C', '\x85', '\x3', '\x2', '\x2', '\x2', '\x8D', '&', 
		'\x3', '\x2', '\x2', '\x2', '\x8E', '\x94', '\a', '$', '\x2', '\x2', '\x8F', 
		'\x90', '\a', '$', '\x2', '\x2', '\x90', '\x93', '\a', '$', '\x2', '\x2', 
		'\x91', '\x93', '\n', '\x2', '\x2', '\x2', '\x92', '\x8F', '\x3', '\x2', 
		'\x2', '\x2', '\x92', '\x91', '\x3', '\x2', '\x2', '\x2', '\x93', '\x96', 
		'\x3', '\x2', '\x2', '\x2', '\x94', '\x92', '\x3', '\x2', '\x2', '\x2', 
		'\x94', '\x95', '\x3', '\x2', '\x2', '\x2', '\x95', '\x97', '\x3', '\x2', 
		'\x2', '\x2', '\x96', '\x94', '\x3', '\x2', '\x2', '\x2', '\x97', '\x98', 
		'\a', '$', '\x2', '\x2', '\x98', '(', '\x3', '\x2', '\x2', '\x2', '\x99', 
		'\x9E', '\x5', '\x31', '\x19', '\x2', '\x9A', '\x9D', '\x5', '\x31', '\x19', 
		'\x2', '\x9B', '\x9D', '\x5', '\x33', '\x1A', '\x2', '\x9C', '\x9A', '\x3', 
		'\x2', '\x2', '\x2', '\x9C', '\x9B', '\x3', '\x2', '\x2', '\x2', '\x9D', 
		'\xA0', '\x3', '\x2', '\x2', '\x2', '\x9E', '\x9C', '\x3', '\x2', '\x2', 
		'\x2', '\x9E', '\x9F', '\x3', '\x2', '\x2', '\x2', '\x9F', '*', '\x3', 
		'\x2', '\x2', '\x2', '\xA0', '\x9E', '\x3', '\x2', '\x2', '\x2', '\xA1', 
		'\xA2', '\a', '\x42', '\x2', '\x2', '\xA2', '\xA7', '\x5', '\x31', '\x19', 
		'\x2', '\xA3', '\xA6', '\x5', '\x31', '\x19', '\x2', '\xA4', '\xA6', '\x5', 
		'\x33', '\x1A', '\x2', '\xA5', '\xA3', '\x3', '\x2', '\x2', '\x2', '\xA5', 
		'\xA4', '\x3', '\x2', '\x2', '\x2', '\xA6', '\xA9', '\x3', '\x2', '\x2', 
		'\x2', '\xA7', '\xA5', '\x3', '\x2', '\x2', '\x2', '\xA7', '\xA8', '\x3', 
		'\x2', '\x2', '\x2', '\xA8', ',', '\x3', '\x2', '\x2', '\x2', '\xA9', 
		'\xA7', '\x3', '\x2', '\x2', '\x2', '\xAA', '\xAB', '\x5', '/', '\x18', 
		'\x2', '\xAB', '\xAF', '\a', '\x30', '\x2', '\x2', '\xAC', '\xAE', '\x5', 
		'\x33', '\x1A', '\x2', '\xAD', '\xAC', '\x3', '\x2', '\x2', '\x2', '\xAE', 
		'\xB1', '\x3', '\x2', '\x2', '\x2', '\xAF', '\xAD', '\x3', '\x2', '\x2', 
		'\x2', '\xAF', '\xB0', '\x3', '\x2', '\x2', '\x2', '\xB0', '\xB5', '\x3', 
		'\x2', '\x2', '\x2', '\xB1', '\xAF', '\x3', '\x2', '\x2', '\x2', '\xB2', 
		'\xB3', '\a', '\x30', '\x2', '\x2', '\xB3', '\xB5', '\x5', '/', '\x18', 
		'\x2', '\xB4', '\xAA', '\x3', '\x2', '\x2', '\x2', '\xB4', '\xB2', '\x3', 
		'\x2', '\x2', '\x2', '\xB5', '.', '\x3', '\x2', '\x2', '\x2', '\xB6', 
		'\xB8', '\x5', '\x33', '\x1A', '\x2', '\xB7', '\xB6', '\x3', '\x2', '\x2', 
		'\x2', '\xB8', '\xB9', '\x3', '\x2', '\x2', '\x2', '\xB9', '\xB7', '\x3', 
		'\x2', '\x2', '\x2', '\xB9', '\xBA', '\x3', '\x2', '\x2', '\x2', '\xBA', 
		'\x30', '\x3', '\x2', '\x2', '\x2', '\xBB', '\xBC', '\t', '\x3', '\x2', 
		'\x2', '\xBC', '\x32', '\x3', '\x2', '\x2', '\x2', '\xBD', '\xBE', '\t', 
		'\x4', '\x2', '\x2', '\xBE', '\x34', '\x3', '\x2', '\x2', '\x2', '\xBF', 
		'\xC1', '\t', '\x5', '\x2', '\x2', '\xC0', '\xBF', '\x3', '\x2', '\x2', 
		'\x2', '\xC1', '\xC2', '\x3', '\x2', '\x2', '\x2', '\xC2', '\xC0', '\x3', 
		'\x2', '\x2', '\x2', '\xC2', '\xC3', '\x3', '\x2', '\x2', '\x2', '\xC3', 
		'\xC4', '\x3', '\x2', '\x2', '\x2', '\xC4', '\xC5', '\b', '\x1B', '\x2', 
		'\x2', '\xC5', '\x36', '\x3', '\x2', '\x2', '\x2', '\xC6', '\xC7', '\a', 
		'\x31', '\x2', '\x2', '\xC7', '\xC8', '\a', ',', '\x2', '\x2', '\xC8', 
		'\xCC', '\x3', '\x2', '\x2', '\x2', '\xC9', '\xCB', '\v', '\x2', '\x2', 
		'\x2', '\xCA', '\xC9', '\x3', '\x2', '\x2', '\x2', '\xCB', '\xCE', '\x3', 
		'\x2', '\x2', '\x2', '\xCC', '\xCD', '\x3', '\x2', '\x2', '\x2', '\xCC', 
		'\xCA', '\x3', '\x2', '\x2', '\x2', '\xCD', '\xCF', '\x3', '\x2', '\x2', 
		'\x2', '\xCE', '\xCC', '\x3', '\x2', '\x2', '\x2', '\xCF', '\xD0', '\a', 
		',', '\x2', '\x2', '\xD0', '\xD1', '\a', '\x31', '\x2', '\x2', '\xD1', 
		'\xD2', '\x3', '\x2', '\x2', '\x2', '\xD2', '\xD3', '\b', '\x1C', '\x2', 
		'\x2', '\xD3', '\x38', '\x3', '\x2', '\x2', '\x2', '\xD4', '\xD5', '\a', 
		'\x31', '\x2', '\x2', '\xD5', '\xD6', '\a', '\x31', '\x2', '\x2', '\xD6', 
		'\xDA', '\x3', '\x2', '\x2', '\x2', '\xD7', '\xD9', '\n', '\x6', '\x2', 
		'\x2', '\xD8', '\xD7', '\x3', '\x2', '\x2', '\x2', '\xD9', '\xDC', '\x3', 
		'\x2', '\x2', '\x2', '\xDA', '\xD8', '\x3', '\x2', '\x2', '\x2', '\xDA', 
		'\xDB', '\x3', '\x2', '\x2', '\x2', '\xDB', '\xDE', '\x3', '\x2', '\x2', 
		'\x2', '\xDC', '\xDA', '\x3', '\x2', '\x2', '\x2', '\xDD', '\xDF', '\a', 
		'\xF', '\x2', '\x2', '\xDE', '\xDD', '\x3', '\x2', '\x2', '\x2', '\xDE', 
		'\xDF', '\x3', '\x2', '\x2', '\x2', '\xDF', '\xE0', '\x3', '\x2', '\x2', 
		'\x2', '\xE0', '\xE1', '\a', '\f', '\x2', '\x2', '\xE1', '\xE2', '\x3', 
		'\x2', '\x2', '\x2', '\xE2', '\xE3', '\b', '\x1D', '\x2', '\x2', '\xE3', 
		':', '\x3', '\x2', '\x2', '\x2', '\x11', '\x2', '\x8C', '\x92', '\x94', 
		'\x9C', '\x9E', '\xA5', '\xA7', '\xAF', '\xB4', '\xB9', '\xC2', '\xCC', 
		'\xDA', '\xDE', '\x3', '\x2', '\x3', '\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
