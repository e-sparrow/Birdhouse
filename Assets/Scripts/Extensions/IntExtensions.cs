namespace ESparrow.Utils.Extensions
{
    public static class IntExtensions
    {
        public static int Pow(this int toPow, int pow)
        {
            int result = toPow;
            for (int i = 0; i < pow; i++)
            {
                result *= toPow;
            }

            return result;
        }
    }
}
