using System;
using ObjectAlgebra.DynamicProxy;

namespace ObjectAlgebra.Ltl
{
    public class PrettyPrint : ILtlExtension<IPrettyPrint>
    {
        public IPrettyPrint Conjunction(IPrettyPrint left, IPrettyPrint right)
        {
            Func<string> f = () => left.Print() + " ∧ " + right.Print();
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }

        public IPrettyPrint Disjunction(IPrettyPrint left, IPrettyPrint right)
        {
            Func<string> f = () => left.Print() + " ∨ " + right.Print();
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }

        public IPrettyPrint Finally(IPrettyPrint child)
        {
            Func<string> f = () => "F" + child.Print();
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }

        public IPrettyPrint Negation(IPrettyPrint child)
        {
            Func<string> f = () => "!" + child.Print();
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }

        public IPrettyPrint Next(IPrettyPrint child)
        {
            Func<string> f = () => "X" + child.Print();
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }

        public IPrettyPrint Proposition(bool val)
        {
            Func<string> f = () => val.ToString();
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }

        public IPrettyPrint Until(IPrettyPrint left, IPrettyPrint right)
        {
            Func<string> f = () => left.Print() + " U " + right.Print();
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }

        public IPrettyPrint Variable(string name)
        {
            Func<string> f = () => name;
            return DelegateWrapper.WrapAs<IPrettyPrint>(f);
        }
    }
}