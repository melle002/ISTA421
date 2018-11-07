//-------------Program.cs---------------------------

using System;

namespace BaseNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Utilities util = new Utilities();

          l1:

            Console.WriteLine("****************************");
            Console.WriteLine("   Base Number Conversion   ");
            Console.WriteLine("****************************");
            Console.WriteLine();

            Console.Write("Please enter the integer to convert: ");


            string n1 = Console.ReadLine();

            int number = int.Parse(n1);
           l2:
            Console.WriteLine();
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("       1|Octal   2|Binary   3|Decimal   4|Start Menu   5|Exit        ");
            Console.WriteLine("*********************************************************************");

            Console.Write("Please enter the base to convert from: ");

            string n2 = Console.ReadLine();
            Console.WriteLine();

                switch (n2)
                {
                    case "1":

                        int result = util.oct2bin(number);

                        Console.WriteLine($"Binary converion: {result}");

                        result = util.oct2dec(number);

                        Console.WriteLine($"Decimal conversion: {result}");

                        break;

                    case "2":

                        result = util.bin2dec(number);

                        Console.WriteLine($"Decimal conversion: {result}");

                        result = util.bin2oct(number);

                        Console.WriteLine($"octal conversion: {result}");

                        break;

                    case "3":

                        result = util.dec2bin(number);

                        Console.WriteLine($"binary conversion is {result}");

                        result = util.dec2oct(number);

                        Console.WriteLine($"octal conversion is {result}");

                        break;

                    case "4":

                        goto l1;

                    case "5":

                        Console.WriteLine("Good Bye!");

                        Environment.Exit(0);

                        break;

                    default:

                        Console.WriteLine("Sorry, invalid selection.");

                        break;

                }

            goto l2;

        }

    }

}
//---------------------Utilities.cs-------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace BaseNumberConversion
{
    class Utilities
    {
        public int dec2bin(int n)
        {
            int acc = 0;

            int factor = 1;

            while (n > 0)
            {

                int i = n % 2;

                n = n / 2;

                acc += i * factor;

                factor *= 10;
            }
            return acc;
        }

        public int dec2oct(int n)
        {
            int acc = 0;

            int factor = 1;

            while (n > 0)
            {
                int i = n % 8;

                n = n / 8;

                acc += i * factor;

                factor *= 10;
            }
            return acc;
        }

        public int bin2dec(int n)
        {
            double acc = 0;

            double power = 0;

            while (n > 0)
            {
                int i = n % 10;

                double j = i * Math.Pow(2, power);

                acc += j;

                power++;

                n = n / 10;
            }
            return (int)acc;
        }

        public int bin2oct(int n)
        {
            int acc = 0;

            int factor = 1;

            while (n > 0)
            {
                int i = n % 1000;

                int j = i % 10;

                int k = ((i / 10) % 10) * 2;

                int l = (i / 100) * 4;

                int m = j + k + l;

                acc += m * factor;

                factor *= 10;

                n = n / 1000;
            }
            return acc;
        }

        public int oct2bin(int n)
        {
            int j = 0;

            int k = 0;

            int answer = 0;

            int factor = 1;

            while (n > 0)
            {
                j = n % 10;

                k = dec2bin(j);

                answer += k * factor;

                factor *= 1000;

                n = n / 10;
            }
            return answer;
        }

        public int oct2dec(int n)
        {
            double acc = 0;

            double factor = 0;

            while (n > 0)
            {
                int i = n % 10;

                acc += (i * Math.Pow(8, factor));

                factor++;

                n = n / 10;
            }
            return (int)acc;
        }
    }
}
