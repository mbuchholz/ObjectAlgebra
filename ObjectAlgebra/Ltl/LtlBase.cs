using System;
using ObjectAlgebra.DynamicProxy;

namespace ObjectAlgebra.Ltl
{
    public class LtlBase : ILtlBase<IEval>
    {
        public IEval Conjunction(IEval left, IEval right)
        {
            Func<String, bool> f = (word) => left.Eval(word) && right.Eval(word);
            return DelegateWrapper.WrapAs<IEval>(f);
        }

        public IEval Disjunction(IEval left, IEval right)
        {
            Func<String, bool> f = (word) => left.Eval(word) || right.Eval(word);
            return DelegateWrapper.WrapAs<IEval>(f);
        }

        public IEval Negation(IEval child)
        {
            Func<String, bool> f = (word) => {
                return !child.Eval(word);
            };
            return DelegateWrapper.WrapAs<IEval>(f);
        }

        public IEval Next(IEval child)
        {
            Func<String, bool> f = (word) => {
                return word.Length != 0 && child.Eval(word.Substring(1));
            };
            return DelegateWrapper.WrapAs<IEval>(f);
        }

        public IEval Proposition(bool val)
        {
            Func<String, bool> f = (word) => {
                return val;
            };
            return DelegateWrapper.WrapAs<IEval>(f);
        }

        public IEval Until(IEval left, IEval right)
        {
            Func<String, bool> f = (word) => {
                return Disjunction(right, Conjunction(left, (Next(Until(left, right))))).Eval(word);
            };
            return DelegateWrapper.WrapAs<IEval>(f);
        }

        public IEval Variable(string name)
        {
            Func<String, bool> f = (word) => {
                return word.Length > 0 && word[0].ToString().Equals(name);
            };
            return DelegateWrapper.WrapAs<IEval>(f);
        }
    }
}
