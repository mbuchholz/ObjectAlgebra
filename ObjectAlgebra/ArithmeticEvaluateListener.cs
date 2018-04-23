using System;
using System.Collections.Generic;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace ObjectAlgebra
{
    public class ArithmeticEvaluateListener : ArithmeticBaseListener
    {
        readonly IExpAlg<IEval> alg;
        readonly Stack<IEval> argStack = new Stack<IEval>();
        readonly Stack<int> opStack = new Stack<int>();

        public ArithmeticEvaluateListener(IExpAlg<IEval> alg)
        {
            this.alg = alg;
        }

        public IEval GetResult() {
            return argStack.Pop();
        }

        public override void ExitExpression([NotNull] ArithmeticParser.ExpressionContext context)
        {
            HandleExpression(context);

            base.ExitExpression(context);
        }

        void HandleExpression([NotNull] ArithmeticParser.ExpressionContext context)
        {
            var left = argStack.Pop();
            var right = argStack.Pop();
            var operation = opStack.Pop();

            switch (operation)
            {
                case ArithmeticParser.PLUS:
                    argStack.Push(alg.Add(left, right));
                    break;
            }
        }

        public override void VisitTerminal([NotNull] ITerminalNode node)
        {
            var symbol = node.Symbol;
            var type = symbol.Type;

            switch (type)
            {
                case ArithmeticParser.NUMBER:
                    argStack.Push(alg.Lit(Int32.Parse(symbol.Text)));
                    break;
                case ArithmeticParser.MINUS:
                case ArithmeticParser.PLUS:
                    opStack.Push(type);
                    break;

            }

            base.VisitTerminal(node);
        }
    }
}
