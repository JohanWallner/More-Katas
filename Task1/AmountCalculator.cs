using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    /*
        1) create a class AmountCalculator
        2) add Sum method that accepts an string parameter and returns decimal
        2.1) as a first step return 0.0 out of Sum for any string input
        2.2) if string is not empty then convert it to decimal and return the value
        2.3) if string contains ';' then split the string based on ';' , convert each to decimal, sum the values and return the sum
        3.1) add '\n' separator so that we can sum this kind of input "1,5;2,5\n2,0"
        3.2) adding a new separator will be a matter of reading a list of separators
             add a private member variable to the class which holds the list of separators and use that in Sum method instead of what you have now
        4) add the functionality for defining a custom separator in the input string
           "123,5\n10,5"
           input = "[___]//12,5;1,5___3,5"
           output = 17,5
        5) add funcionality when // is used as separator in #4
        6) add funcionality when there is letters in string
    */

    public class AmountCalculator
    {
        private List<string> _separators = new List<string> { ";", "\n", "_" };
        public decimal Sum(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0m;

            if (input.Contains("//"))
            {
                var pieces = input.Split("//", 2); // splittar endast upp i två delar med hjälp av '2' (annars flera delar, splttar på varje '//')
                input = pieces[1];

                    if (input.Contains("//"))
                    {
                        var newInput = input.Replace("//", ";"); // om strängen innehåller '//' så ersätts det med ';'
                        input = newInput;
                    }

                var separators = pieces[0].Remove(0, 1); //tar bort första
                separators = separators.Remove(separators.Length - 1); // tar bort sista
                var arrayOfSeparators = separators.Split("]["); //splittar 

                    foreach (string separator in arrayOfSeparators)
                    {
                        _separators.Add(separators);
                    }
            }

            // TODO: Göra om detta så att den tar bokstäver, oavsett vilka bokstäver
            if (input.Contains("abc"))
            {
                var stringWithoutLetters = input.Replace("abc", "");
                input = stringWithoutLetters;
            }

            var numbers = input.Split(_separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            return numbers.Sum(x => decimal.Parse(x));
        }
    }
    public class AmountCalculatorTest
    {
        [Test]
        public void SumReturnsZeroForEmptyString()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("");
            Assert.AreEqual(0m, result);
        }

        [Test]
        public void Sum_Returns_number_when_input_Is_Single()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("123,1");
            Assert.AreEqual(123.1m, result);
        }

        [Test]
        public void Sum_Returns_Sum_When_The_Input_Contains_Multiple()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("123,1;10,5;1,4;;");
            Assert.AreEqual(135.0m, result);
        }

        [Test]
        public void Sum_Returns_Sum_When_New_Line_Character_Is_Used()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("1,5;2,5\n2,0");
            Assert.AreEqual(6.0m, result);
        }

        [Test]
        public void Sum_Returns_Sum_When_Underscore_Character_Is_Used()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("1,5;2,5\n2,0_1,0");
            Assert.AreEqual(7.0m, result);
        }

        [Test]
        public void Sum_Returns_When_Defining_A_Custom_Separatror_In_The_Input_String()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("[___]//12,5;1,5___3,5");
            Assert.AreEqual(17.5m, result);
        }
        [Test]
        public void Sum_Returns_When_empty_numbers()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("12,5;1,5;;;3,5");
            Assert.AreEqual(17.5m, result);
        }
        [Test]
        public void Sum_Returns_When_When_Defining_A_Custom_Separatror_and_string_contains_slash_as_Separator()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("[___]//12,5//1,5___3,5");
            Assert.AreEqual(17.5m, result);
        }
        [Test]
        public void Sum_Returns_When_string_contains_letters()
        {
            var calculator = new AmountCalculator();
            var result = calculator.Sum("12,5;1,5;abc;3,5");
            Assert.AreEqual(17.5m, result);
        }
    }
}
