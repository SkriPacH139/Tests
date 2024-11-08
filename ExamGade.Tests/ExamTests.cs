using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamGradeCalculator;
using System.IO;
using System;
using System.Diagnostics;


namespace ExamGradeCalculator.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ScoreCheck_WhenValidInput_ShouldReturnScore()
        {
            // Arrange
            int min = 0;
            int max = 22;
            string input = "15"; // Имитируемый ввод пользователя
            string message = "Введите баллы за модуль 1";

            using (var stringReader = new StringReader(input))
            {
                Console.SetIn(stringReader); // Устанавливаем имитируемый ввод

                // Act
                int result = Calculator.scoreCheck(message, min, max);

                // Assert
                Assert.AreEqual(int.Parse(input), result, "The method should return the valid score within the specified range.");
            }

        }

        [TestMethod]
        public void ScoreCheck_WhenInvalidInput_ShouldPromptUntilValid()
        {
            // Arrange
            int min = 0;
            int max = 22;
            string invalidInput = "-5\n30\n10"; // Имитируемые попытки: -5, 30, и корректное значение 10
            string message = "Введите баллы за модуль 1";

            using (var stringReader = new StringReader(invalidInput))
            {
                Console.SetIn(stringReader); // Устанавливаем имитируемый ввод

                // Act
                int result = Calculator.scoreCheck(message, min, max);

                // Assert
                Assert.AreEqual(10, result, "The method should prompt until a valid score is entered.");
            }
        }

        [TestMethod]
        public void PrintGrade_WhenTotalScoreIsExcellent_ShouldOutputExcellentGrade()
        {
            // Arrange
            int totalScore = 60;
            string expectedOutput = "\nРезультаты:\nОбщая сумма баллов: 60\nОценка: 5 (отлично)".Replace("\r\n", "\n").Trim();
         
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Calculator.printGrade(totalScore);

                // Assert
                string result = sw.ToString().Replace("\r\n", "\n").Trim();
                Assert.AreEqual(result, expectedOutput, "The output should indicate an excellent grade for a high total score.");
            }
        }


        [TestMethod]
        public void PrintGrade_WhenTotalScoreIsGood_ShouldOutputGoodGrade()
        {
            // Arrange
            int totalScore = 40;
            string expectedOutput = "\nРезультаты:\nОбщая сумма баллов: 40\nОценка: 4 (хорошо)\n".Replace("\r\n", "\n").Trim();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Calculator.printGrade(totalScore);

                // Assert
                string result = sw.ToString().Replace("\r\n", "\n").Trim();
                Assert.IsTrue(result.Contains(expectedOutput), "The output should indicate a good grade for a medium total score.");
            }
        }

        [TestMethod]
        public void PrintGrade_WhenTotalScoreIsSatisfactory_ShouldOutputSatisfactoryGrade()
        {
            // Arrange
            int totalScore = 20;
            string expectedOutput = "\nРезультаты:\nОбщая сумма баллов: 20\nОценка: 3 (удовлетворительно)\n".Replace("\r\n", "\n").Trim();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Calculator.printGrade(totalScore);

                // Assert
                string result = sw.ToString().Replace("\r\n", "\n").Trim();
                Assert.IsTrue(result.Contains(expectedOutput), "The output should indicate a satisfactory grade for an average score.");
            }
        }

        [TestMethod]
        public void PrintGrade_WhenTotalScoreIsUnsatisfactory_ShouldOutputUnsatisfactoryGrade()
        {
            // Arrange
            int totalScore = 10;
            string expectedOutput = "\nРезультаты:\nОбщая сумма баллов: 10\nОценка: 2 (неудовлетворительно)\n".Replace("\r\n", "\n").Trim();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Calculator.printGrade(totalScore);

                // Assert
                string result = sw.ToString().Replace("\r\n", "\n").Trim();
                Assert.IsTrue(result.Contains(expectedOutput), "The output should indicate an unsatisfactory grade for a low score.");
            }
        }

    }
}
