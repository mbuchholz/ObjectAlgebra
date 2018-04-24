using System;
using ObjectAlgebra.DynamicProxy;

namespace ObjectAlgebra.Arithmetic
{
    // Initial object algebra interface for expressions: integers and addition
    public interface IExpAlg<E>
    {
        E Lit(int x);
        E Add(E e1, E e2);
    }

    // ----------------------------------------------------------------------
    //       An object algebra implementing that interface (evaluation)
    // ----------------------------------------------------------------------

    // The evaluation interface
    public interface IEval
    {
        int Eval();
    }

    // The object algebra
    class EvalExpAlg : IExpAlg<IEval>
    {
        public IEval Lit(int x)
        {
            Func<int> f = () => x;
            return DelegateWrapper.WrapAs<IEval>(f);
        }

        public IEval Add(IEval e1, IEval e2)
        {
            Func<int> f = () => e1.Eval() + e2.Eval();
            return DelegateWrapper.WrapAs<IEval>(f);
        }
    }
}
