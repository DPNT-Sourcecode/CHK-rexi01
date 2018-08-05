namespace BeFaster.App.Solutions.FIZ
{
    public static class FizzBuzzSolution
    {
        public static string FizzBuzz(int number)
        {
            if (number % 5 == 0)
                return "Fizz";
            if (number % 3 == 0)
                return "Buzz";
            if (number % 5 != 0 && number % 3 != 0)
                return number.ToString();

            return string.Empty;
        }
    }
}
