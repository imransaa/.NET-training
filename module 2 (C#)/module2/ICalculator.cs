namespace module2
{
    interface ICalculator<T>
    {
        T Add(T a, T b);
        T Subtract(T a, T b);
    }
}