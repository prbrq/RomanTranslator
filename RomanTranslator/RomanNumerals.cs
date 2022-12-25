using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanTranslator
{
    public class RomanNumerals
    {
        private static Dictionary<char, int> romanNumerals = new Dictionary<char, int>()
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

        public static string ToRoman(int n)
        {
            var result = "";
            var input = n.ToString();
            var zerosCounter = 0;
            for (var i = input.Length - 1; i >= 0; i--)
            {
                var number = int.Parse(AddZeros(input[i], zerosCounter));
                result = SingleNumberToRoman(number) + result;
                zerosCounter++;
            }
            return result;
        }

        private static string SingleNumberToRoman(int number)
        {
            if (romanNumerals.ContainsValue(number)) return KeyByValue(number);
            else if (number == 4) return "IV";
            else if (number == 9) return "IX";
            else if (number == 40) return "XL";
            else if (number == 90) return "XC";
            else if (number == 400) return "CD";
            else if (number == 900) return "CM";
            else return CalculateRomanNumber(number);
        }

        private static string CalculateRomanNumber(int number)
        {
            var result = "";
            while (number > 0)
            {
                var max = 1;
                if (number > 1)
                {
                    max = romanNumerals.Where(numeral => numeral.Value <= number).Max(numeral => numeral.Value);
                }
                result = result + KeyByValue(max);
                number -= max;
            }
            return result;
        }

        private static string KeyByValue(int value)
        {
            foreach (var romanNumeral in romanNumerals)
                if (romanNumerals[romanNumeral.Key] == value)
                    return romanNumeral.Key.ToString();
            return "";
        }

        private static string AddZeros(char input, int n)
        {
            string result = input.ToString();
            while (n > 0)
            {
                result += "0";
                n--;
            }
            return result;
        }

        public static int FromRoman(string romanNumeral)
        {
            int sum = 0;
            for (int i = romanNumeral.Length - 1; i >= 0; i--)
            {
                char symbol = romanNumeral[i];
                int number = romanNumerals[symbol];
                if (i != 0)
                {
                    if ((symbol == 'V' || symbol == 'X') && romanNumeral[i - 1] == 'I')
                    {
                        number -= 1;
                        i--;
                    }
                    if ((symbol == 'L' || symbol == 'C') && romanNumeral[i - 1] == 'X')
                    {
                        number -= 10;
                        i--;
                    }
                    if ((symbol == 'D' || symbol == 'M') && romanNumeral[i - 1] == 'C')
                    {
                        number -= 100;
                        i--;
                    }
                }
                sum += number;
            }
            return sum;
        }
    }
}
