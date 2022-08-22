using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servisi.trading.Repos.Security.Verification
{
    public class SimpleCodeGenerator
    {
        const string letters = "abcdefghijklmnopqrstuvwxyz";
        public static string getRandomCode()
        {
            var lettersUpper = letters.ToUpper();

            var randomGenerator = new Random();

            string code = "";

            int randomInt;

            for (int i = 0; i < 5; i++)
            {
                randomInt = randomGenerator.Next(0, letters.Length-1);
                if (i % 2 == 0)
                    code += lettersUpper[randomInt];
                else
                    code += (randomInt % 10).ToString();
            }

            return code;
        }
    }
}
