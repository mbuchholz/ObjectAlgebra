namespace ObjectAlgebra.Ltl
{
    public interface ILtlExtension<T> : ILtlBase<T>
    {
         T Finally(T child);
    }
}