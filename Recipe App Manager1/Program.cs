namespace RecipeAppManager
{

    //class to represent ingredient
    class Ingredient
    {
        //class to represent ingredients in the recie
        public string Name { get; set; }
        //get and setters for the name of ingredient


        public double Quantity { get; set; }
        //get and setters for the quantity of ingredient
        //resettingValues
        public double OriginalQuantity { get; set; }

        public string Unit { get; set; }
        //get and setters for the unit of ingredient
    }

    class Step
    {
        public string Description { get; set; } //description for the steps (get and set)
    }

    class Recipe
    {
        //arrays for soring ingredients and steps
        private Ingredient[] ingredients;

        private Step[] steps;


        //initializing the recipe using constructors with specified counts of ingredient and steps
        public Recipe(int ingredientCount, int stepCount)
        {
            ingredients = new Ingredient[ingredientCount];
            steps = new Step[stepCount];
        }
        //setIngredient
        public void SetIngredient(int index, string name, double quantity, string unit)
        {
            ingredients[index] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
        }
        //setStep
        public void SetStep(int index, string description)
        {
            steps[index] = new Step { Description = description };
        }


        // Method for displaying Recipe
        public void DisplayRecipe()
        {
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i].Description}");
            }
        }
        //Method to scaleRecipe by given factor 
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }
        //Method to reset to original values
        public void ResetQuantities()
        {
            // You may implement resetting quantities to original values here
        }
        //Method to ClearRecipe
        public void ClearRecipe()
        {
            ingredients = new Ingredient[ingredients.Length];
            steps = new Step[steps.Length];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = null;

            while (true)
            {
                Console.WriteLine("\t \t ");
                Console.WriteLine("=============================");
                Console.WriteLine("Recipe Management Application");
                Console.WriteLine("=============================");
                Console.WriteLine("\t \t ");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear Recipe");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice :");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        //prompt user for ingredient details
                        Console.Write("Enter the number of ingredients: ");
                        int ingredientCount = int.Parse(Console.ReadLine());

                        Console.Write("Enter the number of steps: ");
                        int stepCount = int.Parse(Console.ReadLine());

                        recipe = new Recipe(ingredientCount, stepCount);

                        for (int i = 0; i < ingredientCount; i++)
                        {
                            Console.Write($"Enter ingredient {i + 1} name: ");
                            string name = Console.ReadLine();

                            Console.Write($"Enter quantity for {name}: ");
                            double quantity = double.Parse(Console.ReadLine());

                            Console.Write($"Enter unit for {name}: ");
                            string unit = Console.ReadLine();

                            recipe.SetIngredient(i, name, quantity, unit);
                        }

                        for (int i = 0; i < stepCount; i++)
                        {
                            Console.Write($"Enter step {i + 1} description: ");
                            string description = Console.ReadLine();
                            recipe.SetStep(i, description);
                        }
                        break;
                    case 2:
                        if (recipe != null)
                            recipe.DisplayRecipe();
                        else
                            Console.WriteLine("Recipe details not entered yet.");
                        break;
                    case 3:
                        if (recipe != null)
                        {
                            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                            double factor = double.Parse(Console.ReadLine());
                            recipe.ScaleRecipe(factor);
                        }
                        else
                            Console.WriteLine("Recipe details not entered yet.");
                        break;
                    case 4:
                        if (recipe != null)
                            recipe.ResetQuantities();
                        else
                            Console.WriteLine("Recipe details not entered yet.");
                        break;
                    case 5:
                        recipe = null;
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
        }
    }
}


