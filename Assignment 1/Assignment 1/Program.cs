using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_project
{
    using System;
    using System.Collections.Generic;


    // Simple Task List Application

    class Program
    {
        static Dictionary<string, string> tasks = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            DisplayMenu();
        }



        static void DisplayMenu()
        {
            //CRUD
            Console.WriteLine("\n Welcome");
            Console.WriteLine("1. Add a Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("\nEnter ur choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Wrong option.");
                DisplayMenu();
                return;
            }

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    ViewTasks();
                    break;
                case 3:
                    UpdateTask();
                    break;
                case 4:
                    DeleteTask();
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Wrong option.");
                    DisplayMenu();
                    break;
            }
        }

        static void AddTask()
        {
            Console.Write("\nEnter task title: ");
            string title = Console.ReadLine();
            Console.Write("Enter description: ");
            string description = Console.ReadLine();

            tasks[title] = description;

            Console.WriteLine("\nTask added!");
            DisplayMenu();
        }

        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNo tasks found.");
            }
            else
            {
                Console.WriteLine("\nList of Tasks:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Title: {task.Key}, Description: {task.Value}");
                }
            }
            DisplayMenu();
        }

        static void UpdateTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNo tasks found to update.");
                DisplayMenu();
                return;
            }

            Console.Write("\nEnter title of task to update: ");
            string titleToUpdate = Console.ReadLine();

            if (!tasks.ContainsKey(titleToUpdate))
            {
                Console.WriteLine("\nNothing found.");
                DisplayMenu();
                return;
            }

            Console.Write("Enter new task title: ");
            string newTitle = Console.ReadLine();
            Console.Write("Enter new task description: ");
            string newDescription = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(newTitle))
            {
                tasks[newTitle] = tasks[titleToUpdate];
                tasks.Remove(titleToUpdate);
            }
            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                tasks[newTitle] = newDescription;
            }

            Console.WriteLine("\nSuccessfully Task updated!");
            DisplayMenu();
        }

        static void DeleteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("\nNothing to delete.");
                DisplayMenu();
                return;
            }

            Console.Write("\nEnter title of the task to delete:");
            string titleToDelete = Console.ReadLine();

            if (!tasks.ContainsKey(titleToDelete))
            {
                Console.WriteLine("\nTask not found.");
                DisplayMenu();
                return;
            }

            tasks.Remove(titleToDelete);

            Console.WriteLine("\nTask deleted!");
            DisplayMenu();
        }

        static void Exit()
        {
            Console.WriteLine("\nThank you!");
        }
    }

}



