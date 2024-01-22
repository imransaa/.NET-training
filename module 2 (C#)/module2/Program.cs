internal class Program
{
    // Enum
    enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }

    private static void Main(string[] args)
    {
        // Variables & DataTypes
        Console.WriteLine("Hello, World!");

        int integerNumber = 10;
        long longNumber = 999999999;
        float floatingNumber = 3.14f;
        double doubleNumber = 2.71828;
        decimal decimalNumber = 12345.6789m;
        char character = 'A';
        bool isTrue = true;

        Console.WriteLine("Integer Number: " + integerNumber);
        Console.WriteLine("Long Number: " + longNumber);
        Console.WriteLine("Floating Number: " + floatingNumber);
        Console.WriteLine("Double Number: " + doubleNumber);
        Console.WriteLine("Decimal Number: " + decimalNumber);
        Console.WriteLine("Character: " + character);
        Console.WriteLine("Is True? " + isTrue);

        // Using Enums
        DaysOfWeek day = DaysOfWeek.Friday;
        int dayInt = (int)day;

        System.Console.WriteLine(@"Day is {0}, integer value is {1}", day, dayInt);

        int dayNum = 6;
        DaysOfWeek dayOfWeek = (DaysOfWeek)dayNum;

        System.Console.WriteLine(@"Day is {0}, integer value is {1}", dayOfWeek, dayNum);

        // Arrays   
    }
}