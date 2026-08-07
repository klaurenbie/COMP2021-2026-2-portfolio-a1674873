using System.Diagnostics;

namespace ToDo;

class Program
{

    static List<string> tasks = new();
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            try
            {
                Console.Write("Enter a command - add, show, remove, clear, exit: ");
                string? cmd = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(cmd))
                {
                    Console.Write("Please enter a command");
                    continue;
                }

                switch (cmd.ToLower().Trim())
                {
                    case "add":
                        Console.Write("Enter a task: ");
                        string? task = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(task))
                        {
                            Console.WriteLine("Task cannot be empty.");
                            break;
                        }

                        tasks.Add(task);
                        Console.WriteLine("Task added.");
                        break;

                    case "show":
                        Console.Write("Enter index of task for viewing: ");
                        int index = int.Parse(Console.ReadLine());
                        CheckIndex(index);
                        Console.WriteLine($"Task: {tasks[index]}");
                        break;
                    
                    case "remove":
                        Console.Write("Enter index of task for removal: ");
                        index = int.Parse(Console.ReadLine());
                        CheckIndex(index);
                        tasks.RemoveAt(index);
                        Console.WriteLine("Task removed.");
                        break;

                    case "clear":
                        tasks.Clear();
                        Console.WriteLine("Tasks cleared.");
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
    
}


