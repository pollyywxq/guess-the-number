using Xunit;
using GuessTheNumber;

namespace GuessTheNumber.Tests
{
    public class GameTests
    {
        [Fact]
        public void TestCorrectGuess()
        {
            var game = new Game(50);
            var result = game.CheckGuess(50);
            Assert.True(result.IsCorrect);
        }

        [Fact]
        public void TestHigherGuess()
        {
            var game = new Game(50);
            var result = game.CheckGuess(60);
            Assert.False(result.IsCorrect);
            Assert.Equal("Менше!", result.Message);
        }

        [Fact]
        public void TestLowerGuess()
        {
            var game = new Game(50);
            var result = game.CheckGuess(40);
            Assert.False(result.IsCorrect);
            Assert.Equal("Більше!", result.Message);
        }

        [Fact]
        public void TestInvalidInput()
        {
            var game = new Game(50);
            var result = game.CheckGuess(-10);
            Assert.False(result.IsCorrect);
            Assert.Equal("Будь ласка, введіть число від 1 до 100.", result.Message);
        }

        [Fact]
        public void TestNumberOfAttempts()
        {
            var game = new Game(50);
            game.CheckGuess(40);
            game.CheckGuess(60);
            game.CheckGuess(50);
            Assert.Equal(3, game.NumberOfAttempts);
        }
    }

    public class Game
    {
        public int NumberToGuess { get; }
        public int NumberOfAttempts { get; private set; }

        public Game(int numberToGuess)
        {
            NumberToGuess = numberToGuess;
            NumberOfAttempts = 0;
        }

        public GuessResult CheckGuess(int guess)
        {
            NumberOfAttempts++;

            if (guess < 1 || guess > 100)
            {
                return new GuessResult { IsCorrect = false, Message = "Будь ласка, введіть число від 1 до 100." };
            }

            if (guess < NumberToGuess)
            {
                return new GuessResult { IsCorrect = false, Message = "Більше!" };
            }

            if (guess > NumberToGuess)
            {
                return new GuessResult { IsCorrect = false, Message = "Менше!" };
            }

            return new GuessResult { IsCorrect = true, Message = "Вітаємо! Ви вгадали число." };
        }
    }

    public class GuessResult
    {
        public bool IsCorrect { get; set; }
        public string Message { get; set; }
    }
}