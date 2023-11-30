internal class Program
{
    private static void Main(string[] args)
    {
        FunctionCache<int, string> cache = new FunctionCache<int, string>();

        FunctionCache<int, string>.FuncDelegate value1 = (key) =>
                        {
                            Console.WriteLine("Executing expensive operation for key: " + key);
                            return key.ToString();
                        };
        FunctionCache<int, string>.FuncDelegate value = value1;
        FunctionCache<int, string>.FuncDelegate func = value;

        Console.WriteLine("Result 1: " + cache.Execute(func, 1, TimeSpan.FromSeconds(5)));
        Console.WriteLine("Result 2: " + cache.Execute(func, 2, TimeSpan.FromSeconds(5)));
        Console.WriteLine("Result 1 (cached): " + cache.Execute(func, 1, TimeSpan.FromSeconds(5)));
    }
}