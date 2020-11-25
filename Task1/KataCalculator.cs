using NUnit.Framework;
using System;
using System.Linq;

namespace Task1
{
    class KataCalculator
    {
        public int Add(string number)
        {
            if (number.StartsWith("//"))
            {
                var numPart = number.Split(char.Parse("\n"));
                number = numPart[1];
            }
            if (string.IsNullOrWhiteSpace(number))
                return 0;
            if (number.Contains(","))
            {
                var nums = number.Split(',');
                return nums.Sum(Convert.ToInt32);
            }
            return int.Parse(number);
        }
    }
    public class KataCalculatorTest
    {
        [Test]
        public void Returns_Zero_from_empty_string()
        {
            var calculator = new KataCalculator();
            var result = calculator.Add("");
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Returns_sum_from_one_input()
        {
            var calculator = new KataCalculator();
            var result = calculator.Add("1");
            Assert.AreEqual(1, result);
        }
        [Test]
        public void Returns_sum_from_two_input()
        {
            var calculator = new KataCalculator();
            var result = calculator.Add("1,2");
            Assert.AreEqual(3, result);
        }
        [Test]
        public void Returns_sum_from_multiple_input()
        {
            var calculator = new KataCalculator();
            var result = calculator.Add("1,2,3,4,5");
            Assert.AreEqual(15, result);
        }
        [Test]
        public void Returns_zero_from_new_separator()
        {
            var calculator = new KataCalculator();
            var result = calculator.Add("//,\n");
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Returns_sum_from_string_with_new_separator()
        {
            var calculator = new KataCalculator();
            var result = calculator.Add("//,\n1,2");
            Assert.AreEqual(3, result);
        }
    }
}
