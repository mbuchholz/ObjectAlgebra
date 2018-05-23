using Xunit;
using ObjectAlgebra;
using ObjectAlgebra.Ltl;

namespace ObjectAlgebra.Tests {

    public class PrettyPrinting {

        private readonly PrettyPrint _ltlPrint;

        public PrettyPrinting () {
            _ltlPrint = new PrettyPrint();
        }

        [Theory]
        [InlineData("Xb", "Xb")]
        [InlineData("aXb", "a")]
        [InlineData("XXb", "XXb")]
        public void PrintingNextTest (string input, string print) {

            IPrettyPrint printing = Program.BuildAstLTL(_ltlPrint, input);
            Assert.Equal(print, printing.Print());
        }

        [Theory]
        [InlineData("!b", "!b")]
        [InlineData("a!b", "a")]
        public void PrintingNegationTest (string input, string print) {
            
            IPrettyPrint printing = Program.BuildAstLTL(_ltlPrint, input);
            Assert.Equal(print, printing.Print());
        }

        [Theory]
        [InlineData("aUb", "a U b")]
        public void PrintingUntilTest (string input, string print) {

            IPrettyPrint printing = Program.BuildAstLTL(_ltlPrint, input);
            Assert.Equal(print, printing.Print());
        }

        [Theory]
        [InlineData("a&&b", "a ∧ b")]
        public void PrintingConjunctionTest (string input, string print) {

            IPrettyPrint printing = Program.BuildAstLTL(_ltlPrint, input);
            Assert.Equal(print, printing.Print());
        }

        [Theory]
        [InlineData("a||b", "a ∨ b")]
        public void PrintingDisjunctionTest (string input, string print) {

            IPrettyPrint printing = Program.BuildAstLTL(_ltlPrint, input);
            Assert.Equal(print, printing.Print());
        }

        [Theory]
        [InlineData("Fa", "Fa")]
        public void PrintingFinallyTest (string input, string print) {

            IPrettyPrint printing = Program.BuildAstLTL(_ltlPrint, input);
            Assert.Equal(print, printing.Print());
        }

        [Theory]
        [InlineData("X(aU!b)", "Xa U !b")]
        [InlineData("aUXXa", "a U XXa")]
        public void PrintingAllOperatorsTest (string input, string print) {

            IPrettyPrint printing = Program.BuildAstLTL(_ltlPrint, input);
            Assert.Equal(print, printing.Print());
        }
    }
}
