using Xunit;
using ObjectAlgebra;
using ObjectAlgebra.Ltl;

namespace ObjectAlgebra.Tests {

    public class ExtensionFunctionality {

        private readonly LtlExtension _ltlEval;

        public ExtensionFunctionality () {
            _ltlEval = new LtlExtension ();
        }

        [Theory]
        [InlineData ("..Todo..")]
        [InlineData ("..Todo..")]
        public void LtlFinallyTests (string input) {

            IEval evaluation = Program.BuildAstLTL (_ltlEval, "..Todo..");
            Assert.True (evaluation.Eval (input), $"{input} should be true");
        }
    }
}