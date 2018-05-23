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
        public void LtlNextTests(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("acdef", "!b")]
        [InlineData("acbef", "X!b")]
        public void LtlNegationTests(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("xxxxxyxxx", "xUy")]
        [InlineData("yxxyx", "yUXXy")]
        public void LtlUnitlTests(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("xxxxxyxxx", "xUy")]
        public void LtlConjunctionTests(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("acab", "X(!a&&!b)")]
        [InlineData("abababa", "(a&&!b)")]
        public void LtlDisjunctionTests(string input, string ltl) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, ltl);
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }
    }
}
