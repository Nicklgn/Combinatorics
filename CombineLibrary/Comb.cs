using System;
using System.Numerics;
using System.Threading.Tasks;

namespace CombineLibrary
{
    public class Comb
    {
        private static BigInteger TreeMul(BigInteger left, BigInteger right)
        {
            if (left > right) { return 1; }
            if (left == right) { return left; }
            if (right - left == 1) { return left * right; }
            BigInteger n = (left + right) / 2;
            return TreeMul(left, n) * TreeMul(n + 1, right);
        }

        private static BigInteger AsyncTreeMul(int left, int right, int numThread)
        {
            int n = right - left;
            if (n < numThread * 2 || numThread < 2) { return TreeMul(left, right); }
            Task<BigInteger>[] tasks = new Task<BigInteger>[numThread];
            tasks[0] = Task.Run(() => TreeMul(left, n / numThread + left));
            for (int i = 1; i < numThread - 1; i++)
            {
                int a = n / numThread * i + left + 1;
                int b = n / numThread * (i + 1) + left;
                tasks[i] = Task.Run(() => TreeMul(a, b));
            }
            tasks[numThread - 1] = Task.Run(() => TreeMul(n / numThread * (numThread - 1) + left + 1, right));
            Task.WaitAll(tasks);
            BigInteger s = 1;
            for (int i = 0; i < numThread; i++) { s *= tasks[i].Result; }
            return s;
        }

        // Перестановки из n
        public static BigInteger P(int n)
        {
            if (n < 1) { return 0; }
            return TreeMul(2, n);
        }

        // Перестановки из n с многопоточностью
        public static BigInteger P(int n, int numThread)
        {
            if (n < 1) { return 0; }
            return AsyncTreeMul(2, n, numThread);
        }

        // Размещения n по m
        public static BigInteger A(int n, int m)
        {
            if (m > n || n < 1 || m < 1) { return 0; }
            return TreeMul(n - m + 1, n);
        }

        // Размещения n по m с многопоточностью
        public static BigInteger A(int n, int m, int numThread)
        {
            if (m > n || n < 1 || m < 1) { return 0; }
            return AsyncTreeMul(n - m + 1, n, numThread);
        }

        // Сочетания n по m
        public static BigInteger C(int n, int m)
        {
            if (m > n || n < 1 || m < 1) { return 0; }
            int r = n - m;
            int max = Math.Max(r, m);
            BigInteger s1 = TreeMul(max + 1, n);
            int min = Math.Min(r, m);
            BigInteger s2 = TreeMul(2, min);
            return s1 / s2;
        }

        // Сочетания n по m с многопоточностью
        public static BigInteger C(int n, int m, int numThread)
        {
            if (m > n || n < 1 || m < 1) { return 0; }
            int r = n - m;
            int max = Math.Max(r, m);
            BigInteger s1 = AsyncTreeMul(max + 1, n, numThread);
            int min = Math.Min(r, m);
            BigInteger s2 = AsyncTreeMul(2, min, numThread);
            return s1 / s2;
        }
    }
}
