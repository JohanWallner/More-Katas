using NUnit.Framework;

namespace Task1
{
    public class RomanNumeral
    {
        string[] roman_Numbers = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        int[] arabic_Numbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
  
        public string NumberToRomanConverter(int number)
        {
            string romanNumber = "";

            for (int i = 0; i < arabic_Numbers.Length; i++)
            {
                while (number >= arabic_Numbers[i])
                {
                    romanNumber += roman_Numbers[i];
                    number -= arabic_Numbers[i];
                }
            }
            return romanNumber;
        }

        public int RomanToNumberConverter(string roman)
        {
            int arabicNumber = 0;

            for (int i = 0; i < arabic_Numbers.Length; i++)
            {
                while (roman.StartsWith(roman_Numbers[i]))
                {
                    arabicNumber += arabic_Numbers[i];
                    var charactersToRemove = roman_Numbers[i].Length;
                    roman = roman.Remove(0, charactersToRemove);
                }
            }
            return arabicNumber;
        }
    }
    public class RomanNumeralTest
    {
        [Test]
        public void Returns_roman_number_1()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(1);
            Assert.AreEqual("I", result);
        }
        [Test]
        public void Returns_roman_number_2()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(2);
            Assert.AreEqual("II", result);
        }
        [Test]
        public void Returns_roman_number_3()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(3);
            Assert.AreEqual("III", result);
        }
        [Test]
        public void Returns_roman_number_5()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(5);
            Assert.AreEqual("V", result);
        }
        [Test]
        public void Returns_roman_number_8()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(8);
            Assert.AreEqual("VIII", result);
        }
        [Test]
        public void Returns_roman_number_10()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(10);
            Assert.AreEqual("X", result);
        }
        [Test]
        public void Returns_roman_number_11()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(11);
            Assert.AreEqual("XI", result);
        }
        [Test]
        public void Returns_roman_number_17()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(17);
            Assert.AreEqual("XVII", result);
        }
        [Test]
        public void Returns_roman_number_20()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(20);
            Assert.AreEqual("XX", result);
        }
        [Test]
        public void Returns_roman_number_23()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(23);
            Assert.AreEqual("XXIII", result);
        }
        [Test]
        public void Returns_roman_number_333()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(333);
            Assert.AreEqual("CCCXXXIII", result);
        }
        [Test]
        public void Returns_roman_number_1155()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(1155);
            Assert.AreEqual("MCLV", result);
        }
        [Test]
        public void Returns_roman_number_4()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(4);
            Assert.AreEqual("IV", result);
        }
        [Test]
        public void Returns_roman_number_9()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(9);
            Assert.AreEqual("IX", result);
        }
        [Test]
        public void Returns_roman_number_14()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(14);
            Assert.AreEqual("XIV", result);
        }
        [Test]
        public void Returns_roman_number_40()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(40);
            Assert.AreEqual("XL", result);
        }
        [Test]
        public void Returns_roman_number_49()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(49);
            Assert.AreEqual("XLIX", result);
        }
        [Test]
        public void Returns_roman_number_99()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(99);
            Assert.AreEqual("XCIX", result);
        }
        [Test]
        public void Returns_roman_number_999()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(999);
            Assert.AreEqual("CMXCIX", result);
        }
        [Test]
        public void Returns_roman_number_2743()
        {
            var calculator = new RomanNumeral();
            var result = calculator.NumberToRomanConverter(2743);
            Assert.AreEqual("MMDCCXLIII", result);
        }
    }

    public class RomanToNumberTest
    {
        [Test]
        public void Return_number_from_Roman_M()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("M");
            Assert.AreEqual(1000, result);
        }
        [Test]
        public void Return_number_from_Roman_MMM()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("MMM");
            Assert.AreEqual(3000, result);
        }
        [Test]
        public void Return_number_from_Roman_MD()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("MD");
            Assert.AreEqual(1500, result);
        }
        [Test]
        public void Return_number_from_Roman_X()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("X");
            Assert.AreEqual(10, result);
        }
        [Test]
        public void Return_number_from_Roman_CM()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("CM");
            Assert.AreEqual(900, result);
        }
        [Test]
        public void Return_number_from_Roman_CMX()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("CMX");
            Assert.AreEqual(910, result);
        }
        [Test]
        public void Return_number_from_Roman_MDCCXLIX()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("MDCCXLIX");
            Assert.AreEqual(1749, result);
        }
        [Test]
        public void Return_number_from_Roman_LXXXIII()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("LXXXIII");
            Assert.AreEqual(83, result);
        }
        [Test]
        public void Return_number_from_Roman_CCCLXXVIII()
        {
            var calculator = new RomanNumeral();
            var result = calculator.RomanToNumberConverter("CCCLXXVIII");
            Assert.AreEqual(378, result);
        }

    }

}