using System;
using System.Numerics;

namespace TI2
{
    public static class Program
    {
        private static BigInteger gcd(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger t = b;
                b = a % b;
                a = t;
            }

            return a;
        }

        private static (BigInteger, BigInteger, BigInteger) ExtGcd(BigInteger a, BigInteger b)
        {
            if (a < b)
            {
                BigInteger tmp = b;
                b = a;
                a = tmp;
            }

            if (b == 0)
                return (a, 1, 0);

            BigInteger x2 = 1,
                       x1 = 0,
                       y2 = 0,
                       y1 = 1,
                       x, y;

            while (b > 0)
            {
                BigInteger q = a / b;
                BigInteger r = a - q * b;
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

        private static BigInteger fastexp(BigInteger a, BigInteger z, BigInteger m)
        {
            BigInteger x = 1;

            for (; !z.IsZero; --z)
            {
                while (z.IsEven)
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

            BigInteger p, q, e;
            p = BigInteger.Parse(Console.ReadLine());
            q = BigInteger.Parse(Console.ReadLine());
            e = BigInteger.Parse(Console.ReadLine());

            BigInteger n = p * q;
            BigInteger phi = (p - 1) * (q - 1);

            var res = ExtGcd(e, phi);

            BigInteger d = res.Item3;
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
