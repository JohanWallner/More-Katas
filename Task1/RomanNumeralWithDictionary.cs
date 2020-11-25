using NUnit.Framework;
using System.Collections.Generic;

namespace Task1
{
    public class RomanNumeralWithDictionary
    {
        static Dictionary<int, string> arabicToRoman = new Dictionary<int, string>
        {
            { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 6, "VI" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" }
        };

        public string ToRoman(int number)
        {
            string romanNumber = "";

            foreach (int value in arabicToRoman.Keys)
            {
                while (number >= value)
                {
                    romanNumber += arabicToRoman[value];
                    number -= value;
                }
            }

            return romanNumber;
        }

        public int ToArabic(string roman)
        {
            
            int arabicNumber = 0;

            foreach  ( KeyValuePair<int, string> kvp in arabicToRoman)
            {           
                while (roman.StartsWith(kvp.Value))
                {
                    arabicNumber += kvp.Key;
                    var charactersToRemove = kvp.Value.Length;
                    roman = roman.Remove(0, charactersToRemove);
                }
            }

            return arabicNumber;
        }
    }
    public class ToRomanTest
    {
        [TestCase(19, "XIX")]
        [TestCase(1749, "MDCCXLIX")]
        [TestCase(989, "CMLXXXIX")]
        [TestCase(2582, "MMDLXXXII")]
        public void ReturnRoman(int input, string expected)
        {
            var calculator = new RomanNumeralWithDictionary();
            var result = calculator.ToRoman(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
    public class ToArabicTest
    {
        [TestCase("X", 10)]
        [TestCase("MDCCXLIX", 1749)]
        [TestCase("CMLXXXIX", 989)]
        [TestCase("MMDLXXXII", 2582)]
        public void Return_Arabic(string input, int expected)
        {
            var calculator = new RomanNumeralWithDictionary();
            var result = calculator.ToArabic(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}

