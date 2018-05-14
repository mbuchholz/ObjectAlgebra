namespace ObjectAlgebra.Ltl
{
    public class PrettyPrint : ILtlExtension<IPrettyPrint>
    {
        public IPrettyPrint Conjunction(IPrettyPrint left, IPrettyPrint right)
        {
            throw new System.NotImplementedException();
        }

        public IPrettyPrint Disjunction(IPrettyPrint left, IPrettyPrint right)
        {
            throw new System.NotImplementedException();
        }

        public IPrettyPrint Finally(IPrettyPrint child)
        {
            throw new System.NotImplementedException();
        }

        public IPrettyPrint Negation(IPrettyPrint child)
        {
            throw new System.NotImplementedException();
        }

        public IPrettyPrint Next(IPrettyPrint child)
        {
            throw new System.NotImplementedException();
        }

        public IPrettyPrint Proposition(bool val)
        {
            throw new System.NotImplementedException();
        }

        public IPrettyPrint Until(IPrettyPrint left, IPrettyPrint right)
        {
            throw new System.NotImplementedException();
        }

        public IPrettyPrint Variable(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}