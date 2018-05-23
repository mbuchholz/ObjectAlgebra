using Xunit;
using ObjectAlgebra;
using ObjectAlgebra.Ltl;

namespace ObjectAlgebra.Tests {

    public class BasicFunctionality {

        private readonly LtlExtension _ltlEval;
        
        public BasicFunctionality() {
            _ltlEval = new LtlExtension();
        }

        [Theory]
        [InlineData("bab", "Xa")]
        [InlineData("test", "XX(!t&&s")]
        public void LtlNextTest(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("acdef", "!b")]
        [InlineData("acbef", "X!b")]
        public void LtlNegationTest(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("xxxxxyxxx", "xUy")]
        [InlineData("yxxyx", "yUXXy")]
        public void LtlUnitlTest(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("xxxxxyxxx", "xUy")]
        public void LtlConjunctionTest(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("acab", "X(!a&&!b)")]
        [InlineData("abababa", "(a&&!b)")]
        public void LtlDisjunctionTest(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }
    }
}
