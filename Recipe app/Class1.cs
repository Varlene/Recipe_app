using System;

namespace RecipeApp
{
    class RecipeManager
    {
        private string[] ingredientNames;
        private double[] ingredientQuantities;
        private string[] ingredientUnits;
        private string[] recipeSteps;

        public void EnterRecipeDetails()
        {
            Console.WriteLine("Enter the details for your recipe:");

            // Prompt user to enter recipe details
            int numOfIngredients = GetNumberFromUser("Enter the number of ingredients: ");
            ingredientNames = new string[numOfIngredients];
            ingredientQuantities = new double[numOfIngredients];
            ingredientUnits = new string[numOfIngredients];

            // Get ingredient details from user
            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.Write($"Enter name of ingredient #{i + 1}: ");
                ingredientNames[i] = Console.ReadLine();

                ingredientQuantities[i] = GetQuantityFromUser($"Enter quantity of {ingredientNames[i]}: ");

                Console.Write($"Enter unit of measurement for {ingredientNames[i]}: ");
                ingredientUnits[i] = Console.ReadLine();
            }

            int numOfSteps = GetNumberFromUser("Enter the number of steps: ");
            recipeSteps = new string[numOfSteps];

            // Get recipe steps from user
            for (int i = 0; i < numOfSteps; i++)
            {
                Console.Write($"Enter step #{i + 1}: ");
                recipeSteps[i] = Console.ReadLine();
            }
        }

        public void DisplayRecipe()
        {
            if (ingredientNames == null || recipeSteps == null)
            {
                Console.WriteLine("Recipe details are not available. Please enter a recipe first.");
                return;
            }

            // Display recipe details
            Console.WriteLine("\nRecipe Details:");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredientNames.Length; i++)
            {
                Console.WriteLine($"{ingredientQuantities[i]} {ingredientUnits[i]} of {ingredientNames[i]}");
            }
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipeSteps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {recipeSteps[i]}");
            }
        }

        public void ClearRecipe()
        {
            ingredientNames = null;
            ingredientQuantities = null;
            ingredientUnits = null;
            recipeSteps = null;
            Console.WriteLine("Recipe data cleared.");
        }

        public void ScaleRecipe(double scaleFactor)
        {
            if (ingredientQuantities == null)
            {
                Console.WriteLine("No recipe details available to scale. Please enter a recipe first.");
                return;
            }

            Console.WriteLine($"\nScaled Recipe (Factor: {scaleFactor}):");
            for (int i = 0; i < ingredientQuantities.Length; i++)
            {
                Console.WriteLine($"{ingredientQuantities[i] * scaleFactor} {ingredientUnits[i]} of {ingredientNames[i]}");
            }
        }

        private int GetNumberFromUser(string prompt)//commit
        {
            int num;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out num) && num > 0)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }
        }

        private double GetQuantityFromUser(string prompt)
        {
            double quantity;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    return quantity;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
        }
    }
}
