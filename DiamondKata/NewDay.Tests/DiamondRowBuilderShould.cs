using System;
using Xunit;

namespace NewDay.Tests
{
    public class DiamondRowBuilderShould
    {
        [Theory]
        [InlineData('a')]
        [InlineData('z')]
        [InlineData('0')]
        [InlineData('9')]
        [InlineData('?')]
        public void ThrowForInvalidCharacters(char invalidChar)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var sut = new DiamondRowBuilder(new DiamondHelper(), invalidChar);
            });
        }

        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('Z', 2 * 26 - 1)]
        public void CalculateDiamondWidth(char maxChar, int expectedWidth)
        {
            var sut = new DiamondRowBuilder(new DiamondHelper(), maxChar);

            var width = sut.GetDiamondWidth(maxChar);

            Assert.Equal(expectedWidth, width);
        }

        [Theory]
        [InlineData('A', 'A', 0, 0)]
        [InlineData('B', 'A', 1, 1)]
        [InlineData('B', 'B', 0, 2)]
        [InlineData('C', 'A', 2, 2)]
        [InlineData('C', 'B', 1, 3)]
        [InlineData('C', 'C', 0, 4)]
        public void CalculateIndexesToChangeInRow(char maxChar, char currentChar, int expectedIndex1, int expectedIndex2)
        {
            var sut = new DiamondRowBuilder(new DiamondHelper(), maxChar);

            var (idx1, idx2) = sut.GetIndexesForCharToChange(currentChar);

            Assert.Equal(expectedIndex1, idx1);
            Assert.Equal(expectedIndex2, idx2);
        }
    }
}