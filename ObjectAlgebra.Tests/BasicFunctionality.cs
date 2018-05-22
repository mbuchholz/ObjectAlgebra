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
        [InlineData("..Todo..")]
        [InlineData("..Todo..")]
        public void LtlNextTests(string input) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, "..Todo..");
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("..Todo..")]
        [InlineData("..Todo..")]
        public void LtlNegationTests(string input) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, "..Todo..");
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("..Todo..")]
        [InlineData("..Todo..")]
        public void LtlUnitlTests(string input) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, "..Todo..");
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("..Todo..")]
        [InlineData("..Todo..")]
        public void LtlConjunctionTests(string input) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, "..Todo..");
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }

        [Theory]
        [InlineData("..Todo..")]
        [InlineData("..Todo..")]
        public void LtlDisjunctionTests(string input) {
            
            IEval evaluation = Program.BuildAstLTL(_ltlEval, "..Todo..");
            Assert.True(evaluation.Eval(input), $"{input} should be true");
        }
    }
}
