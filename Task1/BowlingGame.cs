using NUnit.Framework;

namespace Task1
{
    public class NewBowlingGame
    {
        int[] pinsDown = new int[21];
        int rollCounter;

        public void Roll(int pins)
        {
            pinsDown[rollCounter] = pins;
            rollCounter++;
        }

        private bool IsStrike(int frameIndex)
        {
            return pinsDown[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return pinsDown[frameIndex] + pinsDown[frameIndex + 1] == 10;
        }

        private int StrikePoints(int frameIndex)
        {
            return pinsDown[frameIndex + 1] + pinsDown[frameIndex + 2];
        }

        private int SparePoints(int frameIndex)
        {
            return pinsDown[frameIndex + 2];
        }

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += 10 + StrikePoints(frameIndex);
                    frameIndex += 1;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SparePoints(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += pinsDown[frameIndex] + pinsDown[frameIndex + 1];
                    frameIndex += 2;
                }
            }

            return score;
        }
    }
    public class BowlingGameTest
    {
        NewBowlingGame game; 

        [SetUp]
        public void SetUpGame()
        {
            game = new NewBowlingGame();
        }

        void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        [Test]
        public void AllGutterBall()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.Score());
        }

        [Test]
        public void AllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [Test]
        public void OneSpare()
        {
            {
                game.Roll(6); game.Roll(4);
                RollMany(18, 1);
            }

            Assert.AreEqual(29, game.Score());
        }

        [Test]
        public void AllSpares()
        {
            {
                RollMany(21, 5);
            }

            Assert.AreEqual(150, game.Score());
        }

        [Test]
        public void OneStrike()
        {
            {
                game.Roll(10);
                RollMany(18, 1);
            }

            Assert.AreEqual(30, game.Score());
        }

        [Test]
        public void AllStrikes()
        {
            {
                RollMany(12, 10);
            }

            Assert.AreEqual(300, game.Score());
        }

        [Test]
        public void Random()
        {
            {
                game.Roll(5); game.Roll(4);
                game.Roll(9); game.Roll(1);
                game.Roll(10);
                game.Roll(6); game.Roll(3);
                game.Roll(4); game.Roll(5);
                game.Roll(10);
                game.Roll(10);
                game.Roll(10);
                game.Roll(6); game.Roll(3);
                game.Roll(5); game.Roll(5); game.Roll(10);
            }

            Assert.AreEqual(170, game.Score());

        }
    }
}
