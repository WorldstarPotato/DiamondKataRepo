namespace NewDay
{
    public class DiamondBuilder
    {
        private readonly DiamondHelper _helper;

        public DiamondBuilder(DiamondHelper helper)
        {
            _helper = helper;
        }

        public List<string> GetAllRows(char centralChar)
        {
            _helper.VerifyCharIsValid(centralChar);

            var result = new List<string>();
            var rowBuilder = new DiamondRowBuilder(_helper, centralChar);

            for (char ch = DiamondHelper.MIN_CHAR; ch <= centralChar; ch++)
                result.Add(rowBuilder.CreateRow(ch));

            for (char ch = (char)(centralChar - 1); ch >= DiamondHelper.MIN_CHAR; ch--)
                result.Add(rowBuilder.CreateRow(ch));

            return result;
        }
    }
}
