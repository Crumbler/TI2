using System;

namespace TI2
{
    public static class Program
    {
        private static ulong gcd(ulong a, ulong b)
        {
            while (b != 0)
            {
                ulong t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        private static (ulong, ulong, ulong) ExtGcd(ulong a, ulong b)
        {
            if (a < b)
            {
                ulong tmp = b;
                b = a;
                a = tmp;
            }

            if (b == 0)
                return (a, 1, 0);

            ulong x2 = 1,
                  x1 = 0,
                  y2 = 0,
                  y1 = 1,
                  x, y;

            while (b > 0)
            {
                ulong q = a / b;
                ulong r = a - q * b;
                x = x2 - q * x1;
                y = y2 - q * y1;

                a = b;
                b = r;
                x2 = x1;
                x1 = x;
                y2 = y1;
                y1 = y;
            }

            return (a, x2, y2);
        }

        private static ulong fastexp(ulong a, ulong z, ulong m)
        {
            ulong x = 1;

            for (; z != 0; --z)
            {
                while (z % 2 == 0)
                {
                    z /= 2;
                    a = (a * a) % m;
                }

                x = (x * a) % m;
            }

            return x;
        }

        private static void GenKey()
        {
            Console.WriteLine("Enter p, q and e");
            ulong p, q, e;
            p = ulong.Parse(Console.ReadLine());
            q = ulong.Parse(Console.ReadLine());
            e = ulong.Parse(Console.ReadLine());

            ulong n = p * q;
            ulong phi = (p - 1) * (q - 1);
        }

        private static void Encrypt()
        {

        }

        private static void Decrypt()
        {

        }

        public static void Main()
        {
            var res = ExtGcd(10, 5);

            Console.WriteLine(res);

            while(true)
            {
                Console.WriteLine("1) Generate key");
                Console.WriteLine("2) Encrypt");
                Console.WriteLine("3) Decrypt");

                string s = Console.ReadLine();

                if (s.Contains('1'))
                    GenKey();
                else if (s.Contains('2'))
                    Encrypt();
                else if (s.Contains('3'))
                    Decrypt();
                else
                {
                    Console.WriteLine("Invalid command");
                    Console.WriteLine("Please try again");
                }
            }
        }
    }
}
