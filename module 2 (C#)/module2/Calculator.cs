namespace module2
{
    public sealed class Calculator : CalculatorBase
    {
        public override int Multiply(int a, int b)
        {
            return a * b;
        }

        public override int Divide(int a, int b)
        {
            return a / b;
        }
    }
}