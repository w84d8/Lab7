class Program
{
    static void Main()
    {
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(
            task => int.Parse(task.Split(',')[0]), // Priority selector
            task => Console.WriteLine($"Initializing task: {task}"), // Initialize task
            task => Console.WriteLine($"Resetting task: {task}") // Reset task
        );

        Console.WriteLine("Enter tasks (format: Priority,Task; enter 'exit' to finish):");
        string input;

        do
        {
            input = Console.ReadLine();

            if (input != "exit")
            {
                scheduler.EnqueueTask(input);
            }

        } while (input != "exit");

        Console.WriteLine("Executing tasks:");

        while (scheduler.GetTaskQueue().Count > 0)
        {
            scheduler.ExecuteNext(task => Console.WriteLine($"Executing task: {task}"));
        }
    }
}