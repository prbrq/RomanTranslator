namespace RomanTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RomanNumerals.FromRoman("MCMXCIV"));
            Console.WriteLine(RomanNumerals.ToRoman(3865));
        }
    }
}