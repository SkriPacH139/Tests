using System;

namespace ExamGradeCalculator
{
    public class Calculator
    {
        public static int scoreCheck(string mes, int min, int max )
        {
            int inNum;
            Console.WriteLine($"{mes} {max}):");
            while (!int.TryParse(Console.ReadLine(), out inNum) || inNum < min || inNum > max) 
            {
                Console.WriteLine($"Некорректный ввод. Пожалуйста, введите целое число от {min} до {max}:");
            }

            return inNum;
        }

        public static void printGrade(int totalScore)
        {
            string grade = totalScore >= 56 ? "5 (отлично)" : totalScore >= 32 ? "4 (хорошо)" : totalScore >= 16 ? "3 (удовлетворительно)" : "2 (неудовлетворительно)";

            Console.WriteLine($"\nРезультаты:\nОбщая сумма баллов: {totalScore}\nОценка: {grade}");
           
        }

        static void Main(string[] args)
        {
            int module1Score, module2Score, module3Score;

            module1Score = scoreCheck("Введите баллы за модуль 1 (Разработка, администрирование и защита баз данных, макс.", 0, 22);

            module2Score = scoreCheck("Введите баллы за модуль 2 (Разработка модулей программного обеспечения для компьютерных систем, макс.", 0, 38);

            module3Score = scoreCheck("Введите баллы за модуль 3 (Сопровождение и обслуживание программного обеспечения компьютерных систем, макс.", 0, 20);

            printGrade(module1Score + module2Score + module3Score);
            Console.ReadKey();

        }
    }
}