﻿using module2;

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
        System.Console.WriteLine("Variables==================================\n");
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
        System.Console.WriteLine("\nenum==================================\n");
        DaysOfWeek day = DaysOfWeek.Friday;
        int dayInt = (int)day;

        System.Console.WriteLine(@"Day is {0}, integer value is {1}", day, dayInt);

        int dayNum = 6;
        DaysOfWeek dayOfWeek = (DaysOfWeek)dayNum;

        System.Console.WriteLine(@"Day is {0}, integer value is {1}", dayOfWeek, dayNum);

        // Arrays   
        System.Console.WriteLine("array==================================\n");
        string[] week = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

        System.Console.WriteLine(@"index 0: {0}", week[0]);

        // Interfaces & abstract classes
        System.Console.WriteLine("\nclassess==================================\n");
        CalculatorBase calculator = new Calculator();

        int a = 10;
        int b = 20;

        System.Console.WriteLine(@"Add : {0}", calculator.Add(a, b));
        System.Console.WriteLine(@"Subtract : {0}", calculator.Subtract(a, b));
        System.Console.WriteLine(@"Divide : {0}", calculator.Divide(a, b));
        System.Console.WriteLine(@"Multiply : {0}", calculator.Multiply(a, b));

        // Generics
        System.Console.WriteLine("Generic==================================\n");
        CalculatorGeneric<double> calDouble = new CalculatorGeneric<double>();
        System.Console.WriteLine(@"Generic Double Add: {0}", calDouble.Add(20.25, 20.25));
        System.Console.WriteLine(@"Generic Double Subtract : {0}", calDouble.Subtract(20.25, 20));

        CalculatorGeneric<string> calString = new CalculatorGeneric<string>();
        System.Console.WriteLine(@"Generic String Add: {0}", calString.Add("Hello ", "World"));
        // System.Console.WriteLine(@"Generic String Subtract: {0}", calString.Subtract("Hello", "World"));

        // Collection
        System.Console.WriteLine("\nCollection==================================\n");
        var trainees = Trainee.TraineeList();

        foreach (var trainee in trainees)
        {
            System.Console.WriteLine(@"Name: {0}, University: {1}", trainee.Name, trainee.University);
        }

        trainees.Add(new Trainee { Name = "Basim", University = "Maju" });

        foreach (var trainee in trainees)
        {
            System.Console.WriteLine(@"Name: {0}, University: {1}", trainee.Name, trainee.University);
        }

        // LINQ
        System.Console.WriteLine("\nLINQ==================================\n");
        var result =
            from trainee in trainees
            group trainee.Name by trainee.University into names
            select new { University = names.Key, Names = names.ToList() };

        foreach (var uni in result)
        {
            System.Console.WriteLine(@"{0}: {1}", uni.University, string.Join(", ", uni.Names));
        }
    }


}