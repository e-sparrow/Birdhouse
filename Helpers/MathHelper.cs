namespace ESparrow.Utils.Helpers
{
    public static class MathHelper
    {
        public static int Factorial(int number)
        {
            var result = number;
            for (int i = 1; i < number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}