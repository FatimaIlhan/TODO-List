using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;

namespace TOD0_List
{
    public class Program
    {
        static List<string> todos = new List<string>();
        static void Main(string[] args)
        {


            bool shallExit = false;
            while (!shallExit)
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[S]ee all TODOs");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");


                var userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "S":
                    case "s":
                        SeeAllTodos();

                        break;
                    case "A":
                    case "a":
                        AddTodo();
                        break;

                    case "R":
                    case "r":
                        RemoveTodos();
                        break;

                    case "E":
                    case "e":
                        shallExit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;


                }


            }

            Console.ReadLine();

            void SeeAllTodos()
            {
                {

                    if (todos.Count == 0)
                    {
                        ShowNoTodosMessage();
                        return;

                    }
                    for (int i = 0; i < todos.Count; i++)
                    {

                        Console.WriteLine($"{i + 1}. {todos[i]}");
                    }
                }
            }
            void AddTodo()
            {
                string description;
                do
                {
                    Console.WriteLine("Enter the TODO description:");
                    description = Console.ReadLine();
                }
                while (!isDescriptionValid(description));
                todos.Add(description);

            }

            bool isDescriptionValid(string description)
            {
                if (description == "")
                {
                    Console.WriteLine("The description cannot be empty. ");
                    return false;
                }
                else if (todos.Contains(description))
                {
                    Console.WriteLine("The description must be unique");
                    return false;
                }
                return true;
            }
            void RemoveTodos()
            {
                {
                    if (todos.Count == 0)
                    {
                        ShowNoTodosMessage();
                        return;
                    }
                    int index;
                    do
                    {
                        Console.WriteLine("Select the index of the TODO you want to remove:");
                        SeeAllTodos();

                    } while (!TryReadIndex(out index));
                    RemoveTodoAtIndex(index - 1);





                    bool TryReadIndex(out int index)
                    {
                        var userInput = Console.ReadLine();
                        if (userInput == "")
                        {
                            index = 0;
                            Console.WriteLine("Selected index cannot be empty.");
                            return false;

                        }
                        if (int.TryParse(userInput, out index) && index >= 1 && index <= todos.Count)
                        {

                            return true;
                        }


                        Console.WriteLine("The given index is not valid.");
                        return false;
                    }

                }
            }
        }
private static void RemoveTodoAtIndex(int index)
        {
            
            var todoToBeRemoved = index;
            todos.RemoveAt(index);
            Console.WriteLine($"TODO removed : {todoToBeRemoved}");
        }

        private static void ShowNoTodosMessage()
        {
            Console.WriteLine("No TODOs have been added yet.");
        }


    }

}
        


            

        
    

