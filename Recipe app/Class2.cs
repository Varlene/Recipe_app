using System;

namespace RecipeApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Recipe Maker!");

            RecipeManager recipeManager = new RecipeManager();
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\n1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Clear Recipe");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipeManager.EnterRecipeDetails();
                        break;
                    case "2":
                        recipeManager.DisplayRecipe();
                        break;
                    case "3":
                        double scaleFactor = GetScaleFactorFromUser();
                        recipeManager.ScaleRecipe(scaleFactor);
                        break;
                    case "4":
                        recipeManager.ClearRecipe();
                        break;
                    case "5":
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }
            }
        }

        static double GetScaleFactorFromUser()
        {
            double scaleFactor;
            while (true)
            {
                Console.Write("Enter the scaling factor: ");
                if (double.TryParse(Console.ReadLine(), out scaleFactor) && scaleFactor > 0)
                {
                    return scaleFactor;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
        }
    }
}
