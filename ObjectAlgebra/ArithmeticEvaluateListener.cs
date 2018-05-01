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

        public ArithmeticEvaluateListener(ISubExpAlg<T> alg)
        {
            this.alg = alg;
        }

        public T GetResult() {
            return arguments.Pop();
        }

        public override void EnterExpression([NotNull] ArithmeticParser.ExpressionContext context)
        {
            var atomContext = context.atom();
            var expressionContexts = context.expression();
            var plusNode = context.PLUS();
            var minusNode = context.MINUS();

            if (atomContext != null) {
                atomContext.EnterRule(this);
            }
            
            if (expressionContexts.Length > 0) {
                foreach (var expressionContext in expressionContexts)
                {
                    expressionContext.EnterRule(this);
                }

                var right = arguments.Pop();
                var left = arguments.Pop();
                T operation;

                if (plusNode != null) {
                    operation = alg.Add(left, right);
                } else {
                    operation = alg.Sub(left, right);
                }

                arguments.Push(operation);
            }

            base.EnterExpression(context);
        }

        public override void EnterAtom([NotNull] ArithmeticParser.AtomContext context)
        {
            var expressionContext = context.expression();
            var numberNode = context.NUMBER();

            if (numberNode != null) {
                arguments.Push(alg.Lit(Int32.Parse(numberNode.GetText())));
            }

            if (expressionContext != null) {
                expressionContext.EnterRule(this);
            }
            
            base.EnterAtom(context);
        }
    }
}
