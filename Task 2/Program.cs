using Task_2;

class Program
{
    static void Main()
    {

        List<string> stringList = new List<string> { "apple", "banana", "cherry", "date" };
        Repository<string> stringRepository = new Repository<string>(stringList);

        Console.WriteLine("Words starting with 'a':");
        List<string> resultStrings = stringRepository.Find(item => item.StartsWith("a"));
        foreach (var str in resultStrings)
        {
            Console.WriteLine(str);
        }
    }
}