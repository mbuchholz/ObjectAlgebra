using System;
using ObjectAlgebra.DynamicProxy;

namespace ObjectAlgebra.Ltl {
    public class EvaluationExtension : Evaluation, ILtlExtension<IEval> {
        public IEval Finally (IEval child) {
            Func<String, bool> f = (word) => {
                return base.Disjunction (child, base.Next (Finally (child))).Eval (word);
            };
            return DelegateWrapper.WrapAs<IEval> (f);
        }
    }
}