using System;
using System.Collections.Generic;
using System.Linq;

public class TaskScheduler<TTask, TPriority> where TPriority : notnull
{
    private readonly SortedDictionary<TPriority, Queue<TTask>> taskQueue = new SortedDictionary<TPriority, Queue<TTask>>();
    private readonly Func<TTask, TPriority> prioritySelector;
    private readonly Action<TTask> initializeTask;
    private readonly Action<TTask> resetTask;

    public TaskScheduler(Func<TTask, TPriority> prioritySelector, Action<TTask> initializeTask, Action<TTask> resetTask)
    {
        this.prioritySelector = prioritySelector ?? throw new ArgumentNullException(nameof(prioritySelector));
        this.initializeTask = initializeTask ?? throw new ArgumentNullException(nameof(initializeTask));
        this.resetTask = resetTask ?? throw new ArgumentNullException(nameof(resetTask));
    }

    public void EnqueueTask(TTask task)
    {
        TPriority priority = prioritySelector(task);

        if (!taskQueue.ContainsKey(priority))
        {
            taskQueue[priority] = new Queue<TTask>();
        }

        taskQueue[priority].Enqueue(task);
    }

    public SortedDictionary<TPriority, Queue<TTask>> GetTaskQueue()
    {
        return new SortedDictionary<TPriority, Queue<TTask>>(taskQueue);
    }

    public void ExecuteNext(Action<TTask> taskExecutor)
    {
        if (taskQueue.Count > 0)
        {
            TPriority highestPriority = taskQueue.Keys.Max();
            TTask nextTask = taskQueue[highestPriority].Dequeue();

            initializeTask(nextTask);
            taskExecutor(nextTask);
            resetTask(nextTask);

            if (taskQueue[highestPriority].Count == 0)
            {
                taskQueue.Remove(highestPriority);
            }
        }
        else
        {
            Console.WriteLine("No tasks in the queue.");
        }
    }
}