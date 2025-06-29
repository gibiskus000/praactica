using System;

namespace RestaurantApp.Utils
{
    public static class PasswordGenerator
    {
        private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string Symbols = "!@#$%^&*()";

        public static string Generate()
        {
            var result = new char[10];
            var random = new Random();

            result[0] = LowerCase[random.Next(LowerCase.Length)];
            result[1] = UpperCase[random.Next(UpperCase.Length)];
            result[2] = Digits[random.Next(Digits.Length)];
            result[3] = Symbols[random.Next(Symbols.Length)];

            for (int i = 4; i < 10; i++)
            {
                string allChars = LowerCase + UpperCase + Digits + Symbols;
                result[i] = allChars[random.Next(allChars.Length)];
            }

            Shuffle(result);
            return new string(result);
        }

        private static void Shuffle(char[] array)
        {
            var rng = new Random();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int j = rng.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}