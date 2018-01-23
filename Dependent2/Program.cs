using Refleksja;

namespace Dependent2
{
    [Description("Zwraca największy wspólny dzielnik liczb")]
    public class NDW : IMethod
    {
        public int Method(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }

            return a;
        }
    }

    [Description("Zwraca większą liczbę")]
    public class Grather : IMethod
    {
        public int Method(int a, int b)
        {
            return a > b ? a : b;
        }
    }

    [Description("Zwraca najmniejszą wspólną wielokrotność liczb")]
    public class NWW : IMethod
    {
        public int Method(int a, int b)
        {
            int x = a * b;
            int w;
            while (b != 0)
            {
                w = a % b;
                a = b;
                b = w;
            }
            return x / a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
