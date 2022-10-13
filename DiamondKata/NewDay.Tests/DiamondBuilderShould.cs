using Xunit;
using System;
using System.Linq;

namespace NewDay.Tests
{
    public class DiamondBuilderShould
    {
        private DiamondBuilder sut;

        public DiamondBuilderShould()
        {
            sut = new DiamondBuilder(new DiamondHelper());
        }

        [Theory]
        [InlineData('a')]
        [InlineData('z')]
        [InlineData('0')]
        [InlineData('9')]
        [InlineData('?')]
        public void ThrowForInvalidCharacters(char invalidChar)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetAllRows(invalidChar));
        }

        [Fact]
        public void Print_A_Diamond()
        {
            var lines = sut.GetAllRows('A');

            Assert.Single(lines);
            Assert.True(lines.All(line => line.Length == 1));
            Assert.Equal("A", lines[0]);
        }

        [Fact]
        public void Print_B_Diamond()
        {
            var lines = sut.GetAllRows('B');

            Assert.Equal(3, lines.Count);
            Assert.True(lines.All(line => line.Length == 3));
            Assert.Equal(" A ", lines[0]);
            Assert.Equal("B B", lines[1]);
            Assert.Equal(" A ", lines[2]);
        }

        [Fact]
        public void Print_C_Diamond()
        {
            var lines = sut.GetAllRows('C');

            Assert.Equal(5, lines.Count);
            Assert.True(lines.All(line => line.Length == 5));
            Assert.Equal("  A  ", lines[0]);
            Assert.Equal(" B B ", lines[1]);
            Assert.Equal("C   C", lines[2]);
            Assert.Equal(" B B ", lines[3]);
            Assert.Equal("  A  ", lines[4]);
        }
    }
}