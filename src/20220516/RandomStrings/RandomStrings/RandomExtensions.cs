using System;


namespace RandomStrings
{
    public static class RandomExtensions
    {
        public static string NextString(this Random rnd, int stringLength)
        {
            var randomString = string.Empty;

            for (int i = 0; i < stringLength; i++)
            {
                var randomUppercaseChar = (char)rnd.Next('A', 'Z' + 1);
                var randomLowercaseChar = (char)rnd.Next('a', 'z' + 1);
                var isUppercase = rnd.Next(0, 2);

                if (isUppercase == 0)
                {
                    randomString += randomLowercaseChar;
                }
                else
                {
                    randomString += randomUppercaseChar;
                }
            }

            return randomString;
        }
    }
}
