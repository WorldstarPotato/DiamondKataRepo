namespace NewDay
{
    public class DiamondBuilder
    {
        private readonly DiamondHelper _helper;

        public DiamondBuilder(DiamondHelper helper)
        {
            _helper = helper;
        }

        public List<string> GetAllRows(char widestChar)
        {
            _helper.VerifyCharIsValid(widestChar);

            var result = new List<string>();
            var rowBuilder = new DiamondRowBuilder(_helper, widestChar);

            for (char ch = DiamondHelper.MIN_CHAR; ch <= widestChar; ch++)
                result.Add(rowBuilder.CreateRow(ch));

            for (char ch = (char)(widestChar - 1); ch >= DiamondHelper.MIN_CHAR; ch--)
                result.Add(rowBuilder.CreateRow(ch));

            return result;
        }
    }
}
