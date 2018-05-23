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
        [InlineData("xxxxxyxxx", "Fy")]
        [InlineData("aaaaax", "aUFx")]
        public void LtlFinallyTests (string input, string ltl) {

            IEval evaluation = Program.BuildAstLTL (_ltlEval, ltl);
            Assert.True (evaluation.Eval (input), $"{input} should be true");
        }
    }
}