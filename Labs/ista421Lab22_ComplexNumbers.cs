//----------Program.cs---------------------

using System;

namespace ComplexNumbers
{
    class Program
    {
        static void doWork()
        {
            Complex first = new Complex(10, 4);
            Complex second = new Complex(5, 2);
            Console.WriteLine($"first is {first}");
            Console.WriteLine($"second is {second}");
            Complex temp = first + second;
            Console.WriteLine($"Add: result is {temp}");
            temp = first - second;
            Console.WriteLine($"Subtract: result is {temp}");
            temp = first * second;
            Console.WriteLine($"Multiply: result is {temp}");
            temp = first / second;
            Console.WriteLine($"Divide: result is {temp}");

            if (temp == first)
            {
                Console.WriteLine("Comparison: temp == first");
            }
            else
            {
                Console.WriteLine("Comparison: temp != first");
            }
            if (temp == temp)
            {
                Console.WriteLine("Comparison: temp == temp");
            }
            else
            {
                Console.WriteLine("Comparison: temp != temp");
            }

            Console.WriteLine($"Current value of temp is {temp}");
            if (temp == 2)
            {
                Console.WriteLine("Comparison after conversion: temp == 2");
            }
            else
            {
                Console.WriteLine("Comparison after conversion: temp != 2");
            }
            temp += 2;
            Console.WriteLine($"Value after adding 2: temp = {temp}");

            int tempInt = (int)temp;
            Console.WriteLine($"Int value after conversion: tempInt == {tempInt}");
        }

        static void Main()
        {
            try
            {
                doWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}
//----------Complex.cs---------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNumbers
{
  class Complex
  {
      public int Real { get; set; }
      public int Imaginary { get; set; }

      public Complex(int real, int imaginary)
      {
          this.Real = real;
          this.Imaginary = imaginary;
      }

      public Complex(int real)
      {
          this.Real = real;
          this.Imaginary = 0;
      }

      public static implicit operator Complex(int from) => new Complex(from);

      public static explicit operator int(Complex from) => from.Real;

      public override string ToString() => $"({this.Real} + {this.Imaginary}i) ";

      public static Complex operator +(Complex lhs, Complex rhs) =>
              new Complex(lhs.Real + rhs.Real, lhs.Imaginary + rhs.Imaginary);

      public static Complex operator -(Complex lhs, Complex rhs) =>
              new Complex(lhs.Real - rhs.Real, lhs.Imaginary - rhs.Imaginary);

      public static Complex operator *(Complex lhs, Complex rhs) =>
              new Complex(lhs.Real * rhs.Real - lhs.Imaginary * rhs.Imaginary,
                  lhs.Imaginary * rhs.Real + lhs.Real * rhs.Imaginary);
      public static Complex operator /(Complex lhs, Complex rhs)
      {
          int realElement = (lhs.Real * rhs.Real + lhs.Imaginary * rhs.Imaginary) /
              (rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary);

          int imaginaryElement = (lhs.Imaginary * rhs.Real - lhs.Real * rhs.Imaginary) /
              (rhs.Real * rhs.Real + rhs.Imaginary * rhs.Imaginary);

          return new Complex(realElement, imaginaryElement);
      }

      public static bool operator ==(Complex lhs, Complex rhs) =>
          lhs.Equals(rhs);

      public static bool operator !=(Complex lhs, Complex rhs) => !(lhs.Equals(rhs));

      public override bool Equals(Object obj)
      {
          if (obj is Complex)
          {
              Complex compare = (Complex)obj;
              return (this.Real == compare.Real) &&
              (this.Imaginary == compare.Imaginary);
          }
          else
          {
              return false;
          }
      }
      public override int GetHashCode()
      {
          return base.GetHashCode();
      }
  }
}
