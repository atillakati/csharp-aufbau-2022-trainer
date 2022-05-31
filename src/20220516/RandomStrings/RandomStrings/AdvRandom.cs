using System;


namespace RandomStrings
{
    public class AdvRandom : Random
    {
        public AdvRandom() : base()
        {

        }

        public AdvRandom(int seed) : base(seed)
        {

        }

        public string NextString(int stringLength)
        {
            var randomString = string.Empty;

            for (int i = 0; i < stringLength; i++)
            {
                var randomUppercaseChar = (char)Next('A', 'Z' + 1);
                var randomLowercaseChar = (char)Next('a', 'z' + 1);
                var isUppercase = Next(0, 2);

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
