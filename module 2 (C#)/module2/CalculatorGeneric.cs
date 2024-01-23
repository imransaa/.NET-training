namespace module2
{
    public class CalculatorGeneric<T> : ICalculator<T>
    {
        public T Add(T a, T b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Arguments Cant be Null");
            }

            dynamic dynamicA = a;
            dynamic dynamicB = b;

            return dynamicA + dynamicB;
        }

        public T Subtract(T a, T b)
        {
            if (a == null || b == null)
            {
                throw new ArgumentNullException("Arguments Cant be Null");
            }

            if(typeof(T) != typeof(int) && typeof(T) != typeof(float) && typeof(T) != typeof(decimal) && typeof(T) != typeof(long) && typeof(T) != typeof(double)){
                throw new ArgumentException("Subtract can not work for this data type");
            }

            dynamic dynamicA = a;
            dynamic dynamicB = b;

            return dynamicA - dynamicB;
        }
    }
}
