using System;
using FractionLibrary;

namespace FractionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створення дробів
            Fraction f1 = new Fraction(3, 4);
            Fraction f2 = new Fraction(2, 5);
            Fraction f3 = new Fraction(6, 8); // Це те саме що 3/4 після скорочення
            Fraction f4 = new Fraction(-1, 2);

            Console.WriteLine("Демонстрація роботи класу Fraction");
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Дріб 1: {f1}");
            Console.WriteLine($"Дріб 2: {f2}");
            Console.WriteLine($"Дріб 3: {f3} (повинен дорівнювати дробу 1 після скорочення)");
            Console.WriteLine($"Дріб 4: {f4}");
            Console.WriteLine();

            // Демонстрація арифметичних операцій
            Console.WriteLine("Арифметичні операції:");
            Console.WriteLine($"{f1} + {f2} = {f1 + f2}");
            Console.WriteLine($"{f1} - {f2} = {f1 - f2}");
            Console.WriteLine($"{f1} * {f2} = {f1 * f2}");
            Console.WriteLine($"{f1} / {f2} = {f1 / f2}");
            Console.WriteLine($"Унарний мінус для {f4} = {-f4}");
            Console.WriteLine();

            // Демонстрація операцій порівняння
            Console.WriteLine("Операції порівняння:");
            Console.WriteLine($"{f1} == {f3} -> {f1 == f3}");
            Console.WriteLine($"{f1} != {f2} -> {f1 != f2}");
            Console.WriteLine($"{f1} > {f2} -> {f1 > f2}");
            Console.WriteLine($"{f1} < {f2} -> {f1 < f2}");
            Console.WriteLine($"{f1} >= {f3} -> {f1 >= f3}");
            Console.WriteLine($"{f1} <= {f3} -> {f1 <= f3}");
            Console.WriteLine();

            // Демонстрація приведення типу
            Console.WriteLine("Приведення типу до double:");
            Console.WriteLine($"(double){f1} = {(double)f1}");
            Console.WriteLine($"(double){f2} = {(double)f2}");
            Console.WriteLine($"(double){f4} = {(double)f4}");
            Console.WriteLine();

            // Демонстрація скорочення дробу
            Console.WriteLine("Скорочення дробу:");
            Fraction f5 = new Fraction(15, 25);
            Console.WriteLine($"Дріб до скорочення: 15/25");
            Console.WriteLine($"Дріб після скорочення: {f5}");
            Console.WriteLine();

            // Демонстрація виняткових ситуацій
            Console.WriteLine("Обробка виняткових ситуацій:");
            try
            {
                Fraction f6 = new Fraction(1, 0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Спроба створити дріб з нульовим знаменником: {ex.Message}");
            }

            try
            {
                Fraction f7 = f1 / new Fraction(0, 1);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Спроба ділення на нуль: {ex.Message}");
            }
        }
    }
}