//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Ltl.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace ObjectAlgebra.Antlr {
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class LtlParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		LPAREN=1, RPAREN=2, NEGATION=3, NEXT=4, FINALLY=5, UNTIL=6, CONJUNCTION=7, 
		DISJUNCTION=8, PROPOSITION=9, VARIABLE=10, WS=11;
	public const int
		RULE_ltl = 0, RULE_conjunction = 1, RULE_binary = 2, RULE_unary = 3, RULE_negation = 4, 
		RULE_proposition = 5;
	public static readonly string[] ruleNames = {
		"ltl", "conjunction", "binary", "unary", "negation", "proposition"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'!'", "'X'", "'F'", "'U'", "'&&'", "'||'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "LPAREN", "RPAREN", "NEGATION", "NEXT", "FINALLY", "UNTIL", "CONJUNCTION", 
		"DISJUNCTION", "PROPOSITION", "VARIABLE", "WS"
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

	public override string GrammarFileName { get { return "Ltl.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static LtlParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public LtlParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public LtlParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class LtlContext : ParserRuleContext {
		public ConjunctionContext[] conjunction() {
			return GetRuleContexts<ConjunctionContext>();
		}
		public ConjunctionContext conjunction(int i) {
			return GetRuleContext<ConjunctionContext>(i);
		}
		public ITerminalNode[] DISJUNCTION() { return GetTokens(LtlParser.DISJUNCTION); }
		public ITerminalNode DISJUNCTION(int i) {
			return GetToken(LtlParser.DISJUNCTION, i);
		}
		public LtlContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_ltl; } }
		public override void EnterRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.EnterLtl(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.ExitLtl(this);
		}
	}

	[RuleVersion(0)]
	public LtlContext ltl() {
		LtlContext _localctx = new LtlContext(Context, State);
		EnterRule(_localctx, 0, RULE_ltl);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 12; conjunction();
			State = 17;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==DISJUNCTION) {
				{
				{
				State = 13; Match(DISJUNCTION);
				State = 14; conjunction();
				}
				}
				State = 19;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ConjunctionContext : ParserRuleContext {
		public BinaryContext[] binary() {
			return GetRuleContexts<BinaryContext>();
		}
		public BinaryContext binary(int i) {
			return GetRuleContext<BinaryContext>(i);
		}
		public ITerminalNode[] CONJUNCTION() { return GetTokens(LtlParser.CONJUNCTION); }
		public ITerminalNode CONJUNCTION(int i) {
			return GetToken(LtlParser.CONJUNCTION, i);
		}
		public ConjunctionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_conjunction; } }
		public override void EnterRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.EnterConjunction(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.ExitConjunction(this);
		}
	}

	[RuleVersion(0)]
	public ConjunctionContext conjunction() {
		ConjunctionContext _localctx = new ConjunctionContext(Context, State);
		EnterRule(_localctx, 2, RULE_conjunction);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 20; binary();
			State = 25;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==CONJUNCTION) {
				{
				{
				State = 21; Match(CONJUNCTION);
				State = 22; binary();
				}
				}
				State = 27;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class BinaryContext : ParserRuleContext {
		public UnaryContext[] unary() {
			return GetRuleContexts<UnaryContext>();
		}
		public UnaryContext unary(int i) {
			return GetRuleContext<UnaryContext>(i);
		}
		public ITerminalNode[] UNTIL() { return GetTokens(LtlParser.UNTIL); }
		public ITerminalNode UNTIL(int i) {
			return GetToken(LtlParser.UNTIL, i);
		}
		public BinaryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_binary; } }
		public override void EnterRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.EnterBinary(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.ExitBinary(this);
		}
	}

	[RuleVersion(0)]
	public BinaryContext binary() {
		BinaryContext _localctx = new BinaryContext(Context, State);
		EnterRule(_localctx, 4, RULE_binary);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 28; unary();
			State = 33;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==UNTIL) {
				{
				{
				State = 29; Match(UNTIL);
				State = 30; unary();
				}
				}
				State = 35;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class UnaryContext : ParserRuleContext {
		public NegationContext negation() {
			return GetRuleContext<NegationContext>(0);
		}
		public ITerminalNode[] NEXT() { return GetTokens(LtlParser.NEXT); }
		public ITerminalNode NEXT(int i) {
			return GetToken(LtlParser.NEXT, i);
		}
		public ITerminalNode[] FINALLY() { return GetTokens(LtlParser.FINALLY); }
		public ITerminalNode FINALLY(int i) {
			return GetToken(LtlParser.FINALLY, i);
		}
		public UnaryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_unary; } }
		public override void EnterRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.EnterUnary(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.ExitUnary(this);
		}
	}

	[RuleVersion(0)]
	public UnaryContext unary() {
		UnaryContext _localctx = new UnaryContext(Context, State);
		EnterRule(_localctx, 6, RULE_unary);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==NEXT || _la==FINALLY) {
				{
				{
				State = 36;
				_la = TokenStream.LA(1);
				if ( !(_la==NEXT || _la==FINALLY) ) {
				ErrorHandler.RecoverInline(this);
				}
				else {
					ErrorHandler.ReportMatch(this);
				    Consume();
				}
				}
				}
				State = 41;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 42; negation();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NegationContext : ParserRuleContext {
		public PropositionContext proposition() {
			return GetRuleContext<PropositionContext>(0);
		}
		public ITerminalNode[] NEGATION() { return GetTokens(LtlParser.NEGATION); }
		public ITerminalNode NEGATION(int i) {
			return GetToken(LtlParser.NEGATION, i);
		}
		public NegationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_negation; } }
		public override void EnterRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.EnterNegation(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.ExitNegation(this);
		}
	}

	[RuleVersion(0)]
	public NegationContext negation() {
		NegationContext _localctx = new NegationContext(Context, State);
		EnterRule(_localctx, 8, RULE_negation);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 47;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==NEGATION) {
				{
				{
				State = 44; Match(NEGATION);
				}
				}
				State = 49;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			State = 50; proposition();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PropositionContext : ParserRuleContext {
		public ITerminalNode PROPOSITION() { return GetToken(LtlParser.PROPOSITION, 0); }
		public ITerminalNode VARIABLE() { return GetToken(LtlParser.VARIABLE, 0); }
		public ITerminalNode LPAREN() { return GetToken(LtlParser.LPAREN, 0); }
		public LtlContext ltl() {
			return GetRuleContext<LtlContext>(0);
		}
		public ITerminalNode RPAREN() { return GetToken(LtlParser.RPAREN, 0); }
		public PropositionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_proposition; } }
		public override void EnterRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.EnterProposition(this);
		}
		public override void ExitRule(IParseTreeListener listener) {
			ILtlListener typedListener = listener as ILtlListener;
			if (typedListener != null) typedListener.ExitProposition(this);
		}
	}

	[RuleVersion(0)]
	public PropositionContext proposition() {
		PropositionContext _localctx = new PropositionContext(Context, State);
		EnterRule(_localctx, 10, RULE_proposition);
		try {
			State = 58;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case PROPOSITION:
				EnterOuterAlt(_localctx, 1);
				{
				State = 52; Match(PROPOSITION);
				}
				break;
			case VARIABLE:
				EnterOuterAlt(_localctx, 2);
				{
				State = 53; Match(VARIABLE);
				}
				break;
			case LPAREN:
				EnterOuterAlt(_localctx, 3);
				{
				State = 54; Match(LPAREN);
				State = 55; ltl();
				State = 56; Match(RPAREN);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '\r', '?', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', '\t', 
		'\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', '\x6', 
		'\t', '\x6', '\x4', '\a', '\t', '\a', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x2', '\a', '\x2', '\x12', '\n', '\x2', '\f', '\x2', '\xE', '\x2', '\x15', 
		'\v', '\x2', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\a', '\x3', '\x1A', 
		'\n', '\x3', '\f', '\x3', '\xE', '\x3', '\x1D', '\v', '\x3', '\x3', '\x4', 
		'\x3', '\x4', '\x3', '\x4', '\a', '\x4', '\"', '\n', '\x4', '\f', '\x4', 
		'\xE', '\x4', '%', '\v', '\x4', '\x3', '\x5', '\a', '\x5', '(', '\n', 
		'\x5', '\f', '\x5', '\xE', '\x5', '+', '\v', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x6', '\a', '\x6', '\x30', '\n', '\x6', '\f', '\x6', '\xE', 
		'\x6', '\x33', '\v', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', 
		'\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x3', '\a', '\x5', '\a', 
		'=', '\n', '\a', '\x3', '\a', '\x2', '\x2', '\b', '\x2', '\x4', '\x6', 
		'\b', '\n', '\f', '\x2', '\x3', '\x3', '\x2', '\x6', '\a', '\x2', '?', 
		'\x2', '\xE', '\x3', '\x2', '\x2', '\x2', '\x4', '\x16', '\x3', '\x2', 
		'\x2', '\x2', '\x6', '\x1E', '\x3', '\x2', '\x2', '\x2', '\b', ')', '\x3', 
		'\x2', '\x2', '\x2', '\n', '\x31', '\x3', '\x2', '\x2', '\x2', '\f', '<', 
		'\x3', '\x2', '\x2', '\x2', '\xE', '\x13', '\x5', '\x4', '\x3', '\x2', 
		'\xF', '\x10', '\a', '\n', '\x2', '\x2', '\x10', '\x12', '\x5', '\x4', 
		'\x3', '\x2', '\x11', '\xF', '\x3', '\x2', '\x2', '\x2', '\x12', '\x15', 
		'\x3', '\x2', '\x2', '\x2', '\x13', '\x11', '\x3', '\x2', '\x2', '\x2', 
		'\x13', '\x14', '\x3', '\x2', '\x2', '\x2', '\x14', '\x3', '\x3', '\x2', 
		'\x2', '\x2', '\x15', '\x13', '\x3', '\x2', '\x2', '\x2', '\x16', '\x1B', 
		'\x5', '\x6', '\x4', '\x2', '\x17', '\x18', '\a', '\t', '\x2', '\x2', 
		'\x18', '\x1A', '\x5', '\x6', '\x4', '\x2', '\x19', '\x17', '\x3', '\x2', 
		'\x2', '\x2', '\x1A', '\x1D', '\x3', '\x2', '\x2', '\x2', '\x1B', '\x19', 
		'\x3', '\x2', '\x2', '\x2', '\x1B', '\x1C', '\x3', '\x2', '\x2', '\x2', 
		'\x1C', '\x5', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x1B', '\x3', '\x2', 
		'\x2', '\x2', '\x1E', '#', '\x5', '\b', '\x5', '\x2', '\x1F', ' ', '\a', 
		'\b', '\x2', '\x2', ' ', '\"', '\x5', '\b', '\x5', '\x2', '!', '\x1F', 
		'\x3', '\x2', '\x2', '\x2', '\"', '%', '\x3', '\x2', '\x2', '\x2', '#', 
		'!', '\x3', '\x2', '\x2', '\x2', '#', '$', '\x3', '\x2', '\x2', '\x2', 
		'$', '\a', '\x3', '\x2', '\x2', '\x2', '%', '#', '\x3', '\x2', '\x2', 
		'\x2', '&', '(', '\t', '\x2', '\x2', '\x2', '\'', '&', '\x3', '\x2', '\x2', 
		'\x2', '(', '+', '\x3', '\x2', '\x2', '\x2', ')', '\'', '\x3', '\x2', 
		'\x2', '\x2', ')', '*', '\x3', '\x2', '\x2', '\x2', '*', ',', '\x3', '\x2', 
		'\x2', '\x2', '+', ')', '\x3', '\x2', '\x2', '\x2', ',', '-', '\x5', '\n', 
		'\x6', '\x2', '-', '\t', '\x3', '\x2', '\x2', '\x2', '.', '\x30', '\a', 
		'\x5', '\x2', '\x2', '/', '.', '\x3', '\x2', '\x2', '\x2', '\x30', '\x33', 
		'\x3', '\x2', '\x2', '\x2', '\x31', '/', '\x3', '\x2', '\x2', '\x2', '\x31', 
		'\x32', '\x3', '\x2', '\x2', '\x2', '\x32', '\x34', '\x3', '\x2', '\x2', 
		'\x2', '\x33', '\x31', '\x3', '\x2', '\x2', '\x2', '\x34', '\x35', '\x5', 
		'\f', '\a', '\x2', '\x35', '\v', '\x3', '\x2', '\x2', '\x2', '\x36', '=', 
		'\a', '\v', '\x2', '\x2', '\x37', '=', '\a', '\f', '\x2', '\x2', '\x38', 
		'\x39', '\a', '\x3', '\x2', '\x2', '\x39', ':', '\x5', '\x2', '\x2', '\x2', 
		':', ';', '\a', '\x4', '\x2', '\x2', ';', '=', '\x3', '\x2', '\x2', '\x2', 
		'<', '\x36', '\x3', '\x2', '\x2', '\x2', '<', '\x37', '\x3', '\x2', '\x2', 
		'\x2', '<', '\x38', '\x3', '\x2', '\x2', '\x2', '=', '\r', '\x3', '\x2', 
		'\x2', '\x2', '\b', '\x13', '\x1B', '#', ')', '\x31', '<',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace ObjectAlgebra.Antlr
