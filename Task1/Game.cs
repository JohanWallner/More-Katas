using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task1
{
    public class Game
    {
        static Dictionary<int, string> BowlingScore = new Dictionary<int, string>
        {
            {0, "-" },
            {10 /* + [kast + 1]*/, "/" },
            {10 /* + [kast + 1] + [kast + 2]*/, "X" }
        };

        // frame innehåller throwOne + throwTwo
        // 10 frame, if frame10 throwOne + throwTwo == 10 then throwThree

        public int Score(string input)
        {
            int score = 0;
            foreach (KeyValuePair<int, string> kvp in BowlingScore)
            {
                while (input.StartsWith(kvp.Value))
                {
                score += kvp.Key;
                var charactersToRemove = kvp.Value.Length;
                input = input.Remove(0, charactersToRemove);
                }
            }
            return score;
        }
    }
    public class GameTest
    {
        [Test]
        public void GutterBall()
        {
            var game = new Game();
            var score = game.Score("-");
            Assert.AreEqual(0, score);
        }

        [TestCase("-", 0)]
        [TestCase("/", 10)]
        [TestCase("X", 11)]

        public void GutterBall2(string input, int expected)
        {
            var game = new Game();
            var result = game.Score(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
