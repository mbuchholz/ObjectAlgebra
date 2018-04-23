using System;
using System.Globalization;
using ObjectAlgebra.DynamicProxy;

namespace ObjectAlgebra.Arithmetic
{
    // ----------------------------------------------------------------------
    //                  Evolution 2: Adding pretty printing
    // ----------------------------------------------------------------------

    public interface IPPrint
    {
        string Print();
    }

    class PrintExpAlg : ISubExpAlg<IPPrint>
    {
        public IPPrint Lit(int x)
        {
            Func<string> f = () => x.ToString(CultureInfo.InvariantCulture);
            return DelegateWrapper.WrapAs<IPPrint>(f);
        }

        public IPPrint Add(IPPrint e1, IPPrint e2)
        {
            Func<string> f = () => e1.Print() + " + " + e2.Print();
            return DelegateWrapper.WrapAs<IPPrint>(f);
        }

        public IPPrint Sub(IPPrint e1, IPPrint e2)
        {
            Func<string> f = () => e1.Print() + " - " + e2.Print();
            return DelegateWrapper.WrapAs<IPPrint>(f);
        }
    }

    // An alternative object algebra for pretty printing:

    // Often, when precise control over the invocation of 
    // methods is not needed, we can simplify object algebras. 
    // For example, here's an alternative implementation 
    // of pretty printing that directly computes a string:
    class PrintExpAlg2 : ISubExpAlg<string>
    {
        public string Lit(int x)
        {
            return x.ToString(CultureInfo.InvariantCulture);
        }

        public string Add(string e1, string e2)
        {
            return e1 + " + " + e2;
        }

        public string Sub(string e1, string e2)
        {
            return e1 + " - " + e2;
        }
    }
}
