using AdvanceCoursework.Services;
using AdvanceCoursework.Utils;

namespace AdvanceCoursework;

class Program
{
    private static ExpenseTrackerApp expensesTrackerApp;
    private static string UserID;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Spending Tracker\n");
        do
        {
            Console.WriteLine("Please enter your UserID:");
            UserID = Console.ReadLine();
            Console.WriteLine("\n");
        } while (UserID.Length <= 0);

        Console.WriteLine($"Hello {UserID}\n");

        expensesTrackerApp = ExpenseTrackerApp.GetInstance(UserID);
        StartApplicatioin();
    }

    static private void DisplayMenu()
    {
        Console.WriteLine("What tab do you want to use:");
        Console.WriteLine("1. Spendings");
        Console.WriteLine("2. Transactions");
        Console.WriteLine("3. Categories");
        Console.WriteLine("4. Reports");
        Console.WriteLine("5. Budgets");
        Console.WriteLine("6. Exit");
        Console.Write("Enter your choice: ");
    }

    private static void StartApplicatioin()
    {

        DisplayMenu();

        string userInput = Console.ReadLine();

        Console.WriteLine();

        switch (userInput.ToLower())
        {
            case "1":
                Console.WriteLine();
                //Spending List Here;
                break;

            case "2":
                Console.WriteLine();
                // Transaction List Here;
                break;

            case "3":
                Console.WriteLine();
                // Category Menu Here;
                CategoryMenu();
                break;

            case "4":
                Console.WriteLine();
                // Report Menu Here;
                break;

            case "5":
                Console.WriteLine();
                // Budget Menu Here;
                break;

            case "6":
                Console.WriteLine();
                Console.WriteLine("Exiting program...");
                Environment.Exit(0);
                return;

            default:
                Console.WriteLine();
                Console.WriteLine("Invalid input. Please try again.");
                break;
        }

    }

    private static void DisplayCategoryMenu()
    {
        Console.WriteLine("What action do you want to perform:");
        Console.WriteLine("1. List All Categories");
        Console.WriteLine("2. Create A Category");
        Console.WriteLine("3. Update A Category");
        Console.WriteLine("4. Delete A Category");
        Console.WriteLine("5. Return To Main Tabs");
        Console.Write("Enter your choice: ");
    }

    private static void DisplayBudgetMenu()
    {
        Console.WriteLine("What action do you want to perform:");
        Console.WriteLine("1. List All My Budget");
        Console.WriteLine("2. Create A Budget");
        Console.WriteLine("3. Update A Budget");
        Console.WriteLine("4. Return To Main Tabs");
        Console.Write("Enter your choice: ");
    }

    private static void CreateCategory()
    {
        Utils.Utils.PrintMessage("Provide a category name:");
        string catName = Utils.Utils.AcceptInformation();
        expensesTrackerApp.AddCategory(catName);
    }

    private static void UpdateCategory()
    {
        Utils.Utils.PrintMessage("Provide a category id:");
        string catId = Utils.Utils.AcceptInformation();
        Utils.Utils.PrintMessage("Provide a category name:");
        string catName = Utils.Utils.AcceptInformation();
        expensesTrackerApp.UpdateCategory(catId,catName);
    }

    private static void DeletCategory()
    {
        Utils.Utils.PrintMessage("Provide a category id:");
        string catId = Utils.Utils.AcceptInformation();
        expensesTrackerApp.DeleteCategory(catId);
    }

    private static void CategoryMenu()
    {
        while (true)
        {

            DisplayCategoryMenu();
            string userInput = Utils.Utils.AcceptInformation();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine();
                    expensesTrackerApp.ListAllCategories();
                    break;

                case "2":
                    Console.WriteLine();
                    CreateCategory();
                    break;

                case "3":
                    Console.WriteLine();
                    UpdateCategory();
                    break;

                case "4":
                    Console.WriteLine();
                    DeletCategory();
                    break;

                case "5":
                    Console.WriteLine();
                    Console.WriteLine("Returning to the main menu...");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

            if (userInput == "5")
            {
                StartApplicatioin();
            }

        }
    }
}

