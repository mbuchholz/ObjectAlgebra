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
            var ltl = new LtlExtension();
            Ltl.IEval test = BuildAstLTL(ltl);

            Console.WriteLine("The LTL formula is: {0}", test.Eval("bbb"));
        }

        public static E BuildAstLTL<E>(ILtlExtension<E> alg)
        {
            String input = "!!!!b";
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
