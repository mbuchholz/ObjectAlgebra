using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ObjectAlgebra.Arithmetic;

namespace ObjectAlgebra
{

    // ----------------------------------------------------------------------
    //                                Testing
    // ----------------------------------------------------------------------

    class Program
    {
        // An expression using the basic ExpAlg
        private static E Exp1<E>(IExpAlg<E> alg)
        {
            return alg.Add(alg.Lit(3), alg.Lit(4));
        }

        // An expression using subtraction too
        private static E Exp2<E>(ISubExpAlg<E> alg)
        {
            return alg.Sub(Exp1(alg), alg.Lit(4));
        }

        private static void Main()
        {
            // Some object algebras:
            var ea = new EvalExpAlg();
            var esa = new EvalSubExpAlg();
            var pa = new PrintExpAlg();
            var pa2 = new PrintExpAlg2();

            // We can call esa with Exp1
            var ev = Exp1(esa);

            // But calling ea with Exp2 is an error
            // var ev_bad = Exp2(ea);

            // Testing the actual algebras
            Console.WriteLine("Evaluation of Exp1 '{0}' is: {1}", Exp1(pa).Print(), ev.Eval());
            Console.WriteLine("Evaluation of Exp2 '{0}' is: {1}", Exp2(pa).Print(), Exp2(esa).Eval());
            Console.WriteLine("The alternative pretty printer works nicely too!{0}Exp1: {1}{0}Exp2: {2}",
                              Environment.NewLine, Exp1(pa2), Exp2(pa2));

            IPPrint printer = BuildAst(pa);
            IEval eval = BuildAst(esa);
            Console.WriteLine("Evaluation through object algebra: {0} = {1}", printer.Print(), eval.Eval());
        }

        public static E BuildAst<E>(ISubExpAlg<E> alg)
        {
            String input = "1 + (2 - 3) + 4";
            ICharStream stream = CharStreams.fromstring(input);
            ITokenSource lexer = new ArithmeticLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            ArithmeticParser parser = new ArithmeticParser(tokens);
            ArithmeticEvaluateListener<E> listener = new ArithmeticEvaluateListener<E>(alg);
            ParseTreeWalker.Default.Walk(listener, parser.expression());

            return listener.GetResult();
        }
    }
}
