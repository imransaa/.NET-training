namespace module2
{
    public abstract class CalculatorBase : ICalculator<int>
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public abstract int Divide(int a, int b);

        public abstract int Multiply(int a, int b);
    }
}