class Program
{
    static void Main()
    {

        Calculator<int> intCalculator = new Calculator<int>();

        intCalculator.OnAdd += (a, b) => a + b;
        intCalculator.OnSubtract += (a, b) => a - b;
        intCalculator.OnMultiply += (a, b) => a * b;
        intCalculator.OnDivide += (a, b) => b != 0 ? a / b : throw new DivideByZeroException();

        Console.WriteLine("Integer calculations:");
        Console.WriteLine($"Add: {intCalculator.Add(5, 3)}");
        Console.WriteLine($"Subtract: {intCalculator.Subtract(10, 4)}");
        Console.WriteLine($"Multiply: {intCalculator.Multiply(6, 7)}");
        Console.WriteLine($"Divide: {intCalculator.Divide(20, 4)}");
        Console.WriteLine();

        Calculator<double> doubleCalculator = new Calculator<double>();

        doubleCalculator.OnAdd += (a, b) => a + b;
        doubleCalculator.OnSubtract += (a, b) => a - b;
        doubleCalculator.OnMultiply += (a, b) => a * b;
        doubleCalculator.OnDivide += (a, b) => b != 0 ? a / b : throw new DivideByZeroException();

        Console.WriteLine("Double calculations:");
        Console.WriteLine($"Add: {doubleCalculator.Add(3.5, 2.1)}");
        Console.WriteLine($"Subtract: {doubleCalculator.Subtract(7.8, 1.2)}");
        Console.WriteLine($"Multiply: {doubleCalculator.Multiply(4.5, 2.5)}");
        Console.WriteLine($"Divide: {doubleCalculator.Divide(10.0, 2.0)}");
    }
}