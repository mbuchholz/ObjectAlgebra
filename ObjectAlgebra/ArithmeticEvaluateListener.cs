using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ObjectAlgebra.Antlr;
using ObjectAlgebra.Arithmetic;

namespace ObjectAlgebra
{
    public class ArithmeticEvaluateListener<T> : ArithmeticBaseListener
    {
        readonly ISubExpAlg<T> alg;
        readonly Stack<T> arguments = new Stack<T>();
        readonly Stack<int> operations = new Stack<int>();

        public ArithmeticEvaluateListener(ISubExpAlg<T> alg)
        {
            this.alg = alg;
        }

        public T GetResult() {
            return arguments.Pop();
        }

        public override void EnterExpression([NotNull] ArithmeticParser.ExpressionContext context)
        {
            base.EnterExpression(context);
        }

        public override void ExitExpression([NotNull] ArithmeticParser.ExpressionContext context)
        {
            HandleExpression(context);

            base.ExitExpression(context);
        }

        public override void EnterAtom([NotNull] ArithmeticParser.AtomContext context)
        {
            base.EnterAtom(context);
        }

        public override void ExitAtom([NotNull] ArithmeticParser.AtomContext context)
        {
            base.ExitAtom(context);
        }

        void HandleExpression([NotNull] ParserRuleContext context)
        {
            while (arguments.Count > 1)
            {
                var right = arguments.Pop();
                var left = arguments.Pop();
                var operation = operations.Pop();

                switch (operation)
                {
                    case ArithmeticParser.PLUS:
                        arguments.Push(alg.Add(left, right));
                        break;
                    case ArithmeticParser.MINUS:
                        arguments.Push(alg.Sub(left, right));
                        break;
                }
            }
        }

        public override void VisitTerminal([NotNull] ITerminalNode node)
        {
            var symbol = node.Symbol;
            var type = symbol.Type;

            switch (type)
            {
                case ArithmeticParser.NUMBER:
                    arguments.Push(alg.Lit(Int32.Parse(symbol.Text)));
                    break;
                case ArithmeticParser.MINUS:
                case ArithmeticParser.PLUS:
                    operations.Push(type);
                    break;

            }

            base.VisitTerminal(node);
        }
    }
}
