using System.Diagnostics;

namespace ToDo;

class Program
{

    static List<string> tasks = new();
    static Dictionary<string, List<int>> tags = new();
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            try
            {
                Console.Write("Enter a command - add, show, remove, clear, tag, get-tagged,exit: ");
                string? cmd = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(cmd))
                {
                    Console.Write("Please enter a command");
                    continue;
                }

                switch (cmd.ToLower().Trim())
                {
                    case "add":
                        AddTask();
                        break;

                    case "show":
                        ShowTask();
                        break;
                    
                    case "remove":
                        RemoveTask();
                        break;

                    case "clear":
                        tasks.Clear();
                        Console.WriteLine("Tasks cleared.");
                        break;

                    case "tag":
                        TagTask();
                        break;
                    
                    case "get-tagged":
                        GetTaggedTasks();
                        break;
                    
                    case "exit":
                        running = false;
                        Console.WriteLine("Goodbye");
                        break;

                    default: Console.WriteLine("Invalid command."); break;

                }
            }
            
            catch (FormatException)
            {
                Console.WriteLine("Please enter appropriate values.");
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    static void CheckIndex(int index)
    {
        if (tasks.Count == 0)
            throw new ArgumentException("No tasks available.");
        
        if (index < 0 || index >= tasks.Count)
            throw new ArgumentException($"Index must be between 0 and {tasks.Count - 1}");
    }
    
    static void AddTask()
    {
        Console.Write("Enter a task: ");
        string? task = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Task cannot be empty.");
            return;
        }

        tasks.Add(task);
        Console.WriteLine("Task added.");
    }

    static void ShowTask()
    {
        Console.Write("Enter index of task for viewing: ");
        int index = int.Parse(Console.ReadLine());
        CheckIndex(index);
        Console.WriteLine($"Task: {tasks[index]}");
    }

    static void RemoveTask()
    {
        Console.Write("Enter index of task for removal: ");
        int index = int.Parse(Console.ReadLine());
        CheckIndex(index);
        tasks.RemoveAt(index);
        Console.WriteLine("Task removed.");
    }

    static void TagTask()
    {
        Console.Write("Enter index of task to tag: ");
        int index = int.Parse(Console.ReadLine());
        CheckIndex(index);

        Console.Write("Enter tag for the task: ");
        string? tag = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(tag))
        {
            Console.WriteLine("Tag cannot be empty.");
            return;
        }

        tags.TryAdd(tag, new List<int>());
        
        if (tags[tag].Contains(index))
        {
            Console.WriteLine($"Task at index {index} is already tagged with '{tag}'.");
            return;
        }
        tags[tag].Add(index);
        Console.WriteLine($"Task at index {index} tagged with '{tag}'.");
    }

    static void GetTaggedTasks()
    {
        Console.Write("Enter tag to retrieve tasks: ");
        string? tag = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(tag))
        {
            Console.WriteLine("Tag cannot be empty.");
            return;
        }

        if (!tags.ContainsKey(tag) || tags[tag].Count == 0)
        {
            Console.WriteLine($"No tasks found with tag '{tag}'.");
            return;
        }

        Console.WriteLine($"Tasks with tag '{tag}':");
        foreach (int index in tags[tag])
        {
            CheckIndex(index);
            Console.WriteLine($"- {tasks[index]} (Index: {index})");
        }
    }


}


