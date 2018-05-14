using System;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using ObjectAlgebra.Ltl;
using ObjectAlgebra.Antlr;

namespace ObjectAlgebra
{
    public class LTLEvaluateListener<T> : LtlBaseListener
    {
        readonly ILtlExtension<T> alg;
        readonly Stack<T> arguments = new Stack<T>();

         public LTLEvaluateListener (ILtlExtension<T> alg){
             this.alg = alg;
         }

         public T GetResult() {
            return arguments.Pop();
        }

        public override void EnterLtl([NotNull] LtlParser.LtlContext context)
        {
            var conjunctionContexts = context.conjunction();
            var disjunctionNode = context.DISJUNCTION();

            if(conjunctionContexts.Length > 0) 
            {
                foreach(var conjunctionContext in conjunctionContexts) 
                {
                    conjunctionContext.EnterRule(this);
                }

                if(disjunctionNode.Length > 0) 
                {
                    var right = arguments.Pop();
                    var left = arguments.Pop();
                    arguments.Push(alg.Disjunction(left, right));
                } 
            }
            base.EnterLtl(context);
        }

        public override void EnterConjunction([NotNull] LtlParser.ConjunctionContext context)
        {
            var binaryContexts = context.binary();
            var conjunctionNode = context.CONJUNCTION();

            if(binaryContexts.Length > 0)
            {
                foreach(var binaryContext in binaryContexts)
                {
                    binaryContext.EnterRule(this);
                }
                if(conjunctionNode.Length > 0)
                {
                    var right = arguments.Pop();
                    var left = arguments.Pop();
                    arguments.Push(alg.Conjunction(left, right));
                }
            }
            base.EnterConjunction(context);
        }

        public override void EnterBinary(LtlParser.BinaryContext context)
        {

            var unaryContexts = context.unary();
            var untilNode = context.UNTIL();

            if(unaryContexts.Length > 0)
            {
                foreach(var unaryContext in unaryContexts)
                {
                    unaryContext.EnterRule(this);
                }
                if(untilNode.Length > 0)
                {
                    var right = arguments.Pop();
                    var left = arguments.Pop();
                    arguments.Push(alg.Until(left, right));
                }
            }
            base.EnterBinary(context);
        }

        public override void EnterUnary(LtlParser.UnaryContext context)
        {
            var negationContext = context.negation();
            var finallyNodes = context.FINALLY();
            var nextNodes = context.NEXT();

            if(negationContext != null)
            {
                negationContext.EnterRule(this);
            }
            if(finallyNodes.Length > 0)
            {
                foreach(var op in finallyNodes){
                    arguments.Push(alg.Finally(arguments.Pop()));
                }
            } else if(nextNodes.Length > 0)
            {
                foreach(var op in nextNodes){
                    arguments.Push(alg.Next(arguments.Pop()));
                }
            }
            base.EnterUnary(context);
        }

        public override void EnterNegation(LtlParser.NegationContext context)
        {
            var propositionContext = context.proposition();
            var negationNodes = context.NEGATION();

            if(propositionContext != null)
            {
                propositionContext.EnterRule(this);
            }
            if(negationNodes.Length > 0)
            {
                foreach(var op in negationNodes) {
                    arguments.Push(alg.Negation(arguments.Pop()));
                }
            }

            base.EnterNegation(context);
        }

        public override void EnterProposition(LtlParser.PropositionContext context)
        {
            var ltlContext = context.ltl();
            var variableNode = context.VARIABLE();
            var propositionNode = context.PROPOSITION();

            if(ltlContext != null)
            {
                ltlContext.EnterRule(this);
            }
            if(variableNode != null)
            {
                arguments.Push(alg.Variable(variableNode.GetText()));
            }
            if(propositionNode != null)
            {
                arguments.Push(alg.Proposition(bool.Parse(propositionNode.GetText())));
            }

            base.EnterProposition(context);
        }
    }
}