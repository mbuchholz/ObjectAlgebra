using System;
namespace ObjectAlgebra.Ltl
{
    public interface ILtlBase<T>
    {
        T Proposition(bool val);
        T Variable(String name);
        T Negation(T child);
        T Next(T child);
        T Until(T left, T right);
        T Conjunction(T left, T right);
        T Disjunction(T left, T right);
    }
}
