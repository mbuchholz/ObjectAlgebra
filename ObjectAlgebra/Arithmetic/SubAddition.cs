using System;
using ObjectAlgebra.DynamicProxy;

namespace ObjectAlgebra.Arithmetic
{
    // ----------------------------------------------------------------------
    //                    Evolution 1: Adding subtraction
    // ----------------------------------------------------------------------

    public interface ISubExpAlg<E> : IExpAlg<E>
    {
        E Sub(E e1, E e2);
    }

    // Updating evaluation:
    class EvalSubExpAlg : EvalExpAlg, ISubExpAlg<IEval>
    {
        public IEval Sub(IEval e1, IEval e2)
        {
            Func<int> f = () => e1.Eval() - e2.Eval();
            return DelegateWrapper.WrapAs<IEval>(f);
        }
    }
}
