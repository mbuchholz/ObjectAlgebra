using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using ObjectAlgebra.Antlr;
using ObjectAlgebra.Ltl;

namespace ObjectAlgebra
{
    public class Program
    {
        private static void Main()
        {
            string formula;
            IEval evaluation;
            IPrettyPrint printing;
            Console.WriteLine("Please enter a LTL formula (press CTRL+Z to exit):");
            Console.WriteLine();

            do {
                formula = Console.ReadLine();
                
                try
                {
                    evaluation = BuildAstLTL(new EvaluationExtension(), formula);
                    printing = BuildAstLTL(new PrettyPrint(), formula);
                    
                    Console.WriteLine("Enter a word that is evaluated against the given ltl formula:");

                    var word = Console.ReadLine(); 
                    Console.WriteLine("The LTL formula {0} is: {1}", printing.Print(), evaluation.Eval(word));
                    
                    Console.WriteLine();
                    Console.WriteLine("Oka, another formula: (CTRL+Z to exit)");
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid formula. Please try again.");
                }
            } while (formula != null);
        }

        public static E BuildAstLTL<E>(ILtlExtension<E> alg, string input)
        {
            ICharStream stream = CharStreams.fromstring(input);
            ITokenSource lexer = new LtlLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            LtlParser parser = new LtlParser(tokens);
            LtlListener<E> listener = new LtlListener<E>(alg);

            parser.ltl().EnterRule(listener);

            return listener.GetResult();
        }
    }
}
