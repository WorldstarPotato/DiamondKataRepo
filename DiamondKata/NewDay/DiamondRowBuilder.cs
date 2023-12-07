namespace NewDay
{
    public class DiamondRowBuilder
    {
        private readonly DiamondHelper _helper;
        private readonly char _centralChar;
        private readonly int _diamondWidth;

        public DiamondRowBuilder(DiamondHelper helper, char centralChar)
        {
            _helper = helper;
            _centralChar = centralChar;
            _helper.VerifyCharIsValid(centralChar);
            _diamondWidth = GetDiamondWidth();
        }

        public string CreateRow(char lastChar)
        {
            var chars = Enumerable.Repeat(' ', _diamondWidth).ToArray();

            var (idx1, idx2) = GetIndexesForCharToChange(lastChar);
            chars[idx1] = lastChar;
            chars[idx2] = lastChar;

            return new String(chars);
        }

        public int GetDiamondWidth()
        {
            return 2 * (_centralChar - DiamondHelper.MIN_CHAR) + 1;
        }

        public (int idx1, int idx2) GetIndexesForCharToChange(char ch)
        {
            var positionOfChar = _centralChar - ch;
            return (positionOfChar, _diamondWidth - positionOfChar - 1);
        }
    }
}
