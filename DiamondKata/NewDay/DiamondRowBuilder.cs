namespace NewDay
{
    public class DiamondRowBuilder
    {
        private readonly DiamondHelper _helper;
        private readonly char _widestChar;
        private readonly int _diamondWidth;

        public DiamondRowBuilder(DiamondHelper helper, char widestChar)
        {
            _helper = helper;
            _widestChar = widestChar;
            _helper.VerifyCharIsValid(widestChar);
            _diamondWidth = GetDiamondWidth(_widestChar);
        }

        public string CreateRow(char lastChar)
        {
            var chars = Enumerable.Repeat(' ', _diamondWidth).ToArray();

            var (idx1, idx2) = GetIndexesForCharToChange(lastChar);
            chars[idx1] = lastChar;
            chars[idx2] = lastChar;

            return new String(chars);
        }

        public int GetDiamondWidth(char lastChar)
        {
            return 2 * (lastChar - DiamondHelper.MIN_CHAR) + 1;
        }

        public (int idx1, int idx2) GetIndexesForCharToChange(char ch)
        {
            var positionOfChar = _widestChar - ch;
            return (positionOfChar, _diamondWidth - positionOfChar - 1);
        }
    }
}
