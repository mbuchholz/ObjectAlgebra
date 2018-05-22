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
            String input = "!a&&Fc";

            var ltlEval = new LtlExtension();
            var ltlPrint = new PrettyPrint();
            IEval evaluation = BuildAstLTL(ltlEval, input);
            IPrettyPrint printing = BuildAstLTL(ltlPrint, input);

            Console.WriteLine("The LTL formula {0} is: {1}", printing.Print(), evaluation.Eval("bbbc"));
        }

        public static E BuildAstLTL<E>(ILtlExtension<E> alg, string input)
        {
            ICharStream stream = CharStreams.fromstring(input);
            ITokenSource lexer = new LtlLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            LtlParser parser = new LtlParser(tokens);
            LTLEvaluateListener<E> listener = new LTLEvaluateListener<E>(alg);

            parser.ltl().EnterRule(listener);

            return listener.GetResult();
        }
    }
}
