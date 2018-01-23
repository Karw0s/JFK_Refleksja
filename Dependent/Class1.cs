
namespace Dependent
{
    using Refleksja;

    [Description("Mnożenie dwóch liczb typu int")]
    public class Multiply : IMethod
    {
        int IMethod.Method(int a, int b)
        {
            return a * b;
        }
    }

    [Description("Zwraca wynik sumowania dwóch liczb")]
    public class Sum : IMethod
    {
        public int Method(int a, int b)
        {
            return a + b;
        }
    }

    [Description("Zwraca mniejszą liczbę z dwóch")]
    public class Lower : IMethod
    {
        public int Method(int a, int b)
        {
            return a < b ? a : b;
        }
    }
}
