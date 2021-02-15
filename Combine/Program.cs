using System;
using CombineLibrary;

namespace Combine
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10, m = 5, numThread = 4;
            Console.WriteLine(Comb.P(n));
            Console.WriteLine(Comb.A(n, m));
            Console.WriteLine(Comb.C(n, m));
            Console.WriteLine(Comb.P(n, numThread));
            Console.WriteLine(Comb.A(n, m, numThread));
            Console.WriteLine(Comb.C(n, m, numThread));
        }
    }
}
