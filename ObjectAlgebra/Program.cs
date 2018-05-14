using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ObjectAlgebra.Antlr;
using ObjectAlgebra.Ltl;

namespace ObjectAlgebra
{
    class Program
    {
        private static void Main()
        {
            String input = "!!!!b";
            ICharStream stream = CharStreams.fromstring(input);
            ITokenSource lexer = new LtlLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            LtlParser parser = new LtlParser(tokens);

            var ltlEval = new LtlExtension();
            var ltlPrint = new PrettyPrint();
            IEval evaluation = BuildAstLTL(parser, ltlEval);
            IPrettyPrint printing = BuildAstLTL(parser, ltlPrint);

            Console.WriteLine("The LTL formula is: {0}", evaluation.Eval("bbb"));
        }

        public static E BuildAstLTL<E>(LtlParser parser,ILtlExtension<E> alg)
        {
            LTLEvaluateListener<E> listener = new LTLEvaluateListener<E>(alg);

            parser.ltl().EnterRule(listener);

            return listener.GetResult();
        }
    }
}
