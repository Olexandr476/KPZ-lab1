using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionLibrary
{
    public class Fraction : IEquatable<Fraction>
    {
        private const string ZeroDenominatorMessage = "Знаменник не може бути нулем.";
        private int numerator;
        private int denominator;

        // Конструктори
        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException(ZeroDenominatorMessage);

            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
        }

        public Fraction(Fraction other)
        {
            numerator = other.numerator;
            denominator = other.denominator;
        }

        // Властивості
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; Simplify(); }
        }

        public int Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                    throw new ArgumentException(ZeroDenominatorMessage);
                denominator = value;
                Simplify();
            }
        }

        // Метод для скорочення дробу
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }
        }

        // Найбільший спільний дільник (НСД)
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Перевантаження унарних операторів
        public static Fraction operator +(Fraction f) => f;
        public static Fraction operator -(Fraction f) => new Fraction(-f.numerator, f.denominator);

        // Перевантаження бінарних арифметичних операторів
        public static Fraction operator +(Fraction a, Fraction b)
        {
            int newNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            int newNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            int newDenominator = a.denominator * b.denominator;
            return new Fraction(newNumerator, newDenominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
                throw new DivideByZeroException("Ділення на нульовий дріб неможливе.");
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        // Перевантаження операторів порівняння
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.numerator == b.numerator && a.denominator == b.denominator;
        }

        public static bool operator !=(Fraction a, Fraction b) => !(a == b);

        public static bool operator <(Fraction a, Fraction b)
        {
            return (double)a < (double)b;
        }

        public static bool operator >(Fraction a, Fraction b) => b < a;

        public static bool operator <=(Fraction a, Fraction b) => !(a > b);

        public static bool operator >=(Fraction a, Fraction b) => !(a < b);

        // Оператор приведення типу до double
        public static explicit operator double(Fraction f)
        {
            return (double)f.numerator / f.denominator;
        }

        // Перевизначення методів Object
        public bool Equals(Fraction other)
        {
            if (other is null) return false;
            return this.numerator == other.numerator && this.denominator == other.denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

        // Перевизначення ToString()
        public override string ToString()
        {
            return $"{numerator}/{denominator}";
        }
    }
}
