namespace NewDay
{
    public class DiamondHelper
    {
        public const char MIN_CHAR = 'A';
        public const char MAX_CHAR = 'Z';

        public void VerifyCharIsValid(char ch)
        {
            if (ch < MIN_CHAR || ch > MAX_CHAR)
                throw new ArgumentOutOfRangeException(nameof(ch));
        }
    }
}
