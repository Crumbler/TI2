using System;

namespace TI2
{
    public static class Program
    {
        private static long gcd(long a, long b)
        {
            while (b != 0)
            {
                long t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        private static (long, long, long) ExtGcd(long a, long b)
        {
            if (a < b)
            {
                long tmp = b;
                b = a;
                a = tmp;
            }

            if (b == 0)
                return (a, 1, 0);

            long x2 = 1,
                  x1 = 0,
                  y2 = 0,
                  y1 = 1,
                  x, y;

            while (b > 0)
            {
                long q = a / b;
                long r = a - q * b;
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

        private static long fastexp(long a, long z, long m)
        {
            long x = 1;

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

            long p, q, e;
            p = long.Parse(Console.ReadLine());
            q = long.Parse(Console.ReadLine());
            e = long.Parse(Console.ReadLine());

            long n = p * q;
            long phi = (p - 1) * (q - 1);

            var res = ExtGcd(e, phi);

            long d = res.Item3;
            if (d < 0)
                d = res.Item2;

            Console.WriteLine($"The public key is  ({d}, {n})");
            Console.WriteLine($"The private key is ({e}, {n})");

            Console.WriteLine(res);
        }

        private static void Encrypt()
        {

        }

        private static void Decrypt()
        {

        }

        public static void Main()
        {
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
