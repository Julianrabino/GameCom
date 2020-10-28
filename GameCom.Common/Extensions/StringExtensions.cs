namespace GameCom.Common.Extensions
{
    public static class StringExtensions
    {
        public static int TryParseToInt(this string str, int defaultValue = 0)
        {
            return str != null && int.TryParse(str, out int result) ? result : defaultValue;
        }
    }
}
