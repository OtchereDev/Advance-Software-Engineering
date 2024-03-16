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
                BudgetMenu();
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

    private static void DisplayBudgetMenu()
    {
        Console.WriteLine("What action do you want to perform:");
        Console.WriteLine("1. List All My Budget");
        Console.WriteLine("2. Create A Budget");
        Console.WriteLine("3. Get A Budget");
        Console.WriteLine("4. Update A Budget");
        Console.WriteLine("5. Delete A Budget");
        Console.WriteLine("6. Return To Main Tabs");
        Console.Write("Enter your choice: ");
    }

    private static void CreatBudgetItem(string budgetId)
    {
        Console.WriteLine("Provide the amount allocation for this budget item");
        float amount = Utils.Utils.AcceptFloatInformation();

        Console.WriteLine("Provide the categoryid for this budget item");
        string catId = Utils.Utils.AcceptInformation();

        Console.WriteLine("Is this budget item for expenses (YES) or incomes (NO)");
        bool isExpense = Utils.Utils.AcceptBooleanInformation();

        expensesTrackerApp.AddBudgetItem(budgetId, amount, catId, isExpense);
    }

    private static void CreateBudget()
    {
        Utils.Utils.PrintMessage("Provide a budget year:");
        int year = Utils.Utils.AcceptIntegerInformation();

        Utils.Utils.PrintMessage("Provide budget month eg: MAR / JUN");
        string month = Utils.Utils.AcceptInformation();

        var response = expensesTrackerApp.AddBudget(month, year);

        if (response != null)
        {
            while (true)
            {
                Console.WriteLine("Would you like to add a budget item to your budget (YES / NO):");
                string uInput = Utils.Utils.AcceptInformation();

                if(uInput.ToLower() == "yes")
                {
                    CreatBudgetItem(response.BudgetID);
                }
                else if(uInput.ToLower() == "no")
                {
                    break;
                }

                Console.WriteLine("Invalid response. Provide either YES / NO");
            }
        }
        
    }

    private static void DeleteBudget()
    {
        Utils.Utils.PrintMessage("Provide a budget id:");
        string budId = Utils.Utils.AcceptInformation();
        expensesTrackerApp.DeleteBudget(budId);
    }

    private static void GetBudget()
    {
        Utils.Utils.PrintMessage("Provide a budget id:");
        string budId = Utils.Utils.AcceptInformation();
        expensesTrackerApp.GetBudgetById(budId);
    }

    private static void DeleteBudgetItem(string budgetId)
    {
        Utils.Utils.PrintMessage("Provide a budget item id to be deleted");
        string budId = Utils.Utils.AcceptInformation();
        expensesTrackerApp.DeletBudgetItem(budId, budgetId);
    }

    private static void UpdateBudgetItem(string budgetId)
    {
        Utils.Utils.PrintMessage("Provide a budget item id to be deleted");
        string budId = Utils.Utils.AcceptInformation();
        Utils.Utils.PrintMessage("Provide the amount for this budget item");
        float amount = Utils.Utils.AcceptFloatInformation();
        expensesTrackerApp.UpdateBudgetItem(budId, budgetId, amount);
    }

    private static void UpdateBudget()
    {
        Utils.Utils.PrintMessage("Provide a budget id for the budget you want to update:");
        string budId = Utils.Utils.AcceptInformation();
        var budget = expensesTrackerApp.GetBudgetById(budId);

        if(budget != null)
        {
            while (true)
            {
                Console.WriteLine("Do you want to add or delete or update a budget item from this budget");
                Console.WriteLine("1. Delete");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Add");
                Console.WriteLine("Enter either 1 or 2 or 3");
                string uInput = Utils.Utils.AcceptInformation();

                if (uInput == "1")
                {
                    DeleteBudgetItem(budId);
                }
                else if(uInput == "2")
                {
                    UpdateBudgetItem(budId);
                }
                else if (uInput == "3")
                {
                    CreatBudgetItem(budId);
                }

                Console.WriteLine("Invalid input was provided. Enter either 1 or 2 or 3");
            }
        }
    }

    private static void BudgetMenu()
    {
        while (true)
        {
            DisplayBudgetMenu();
            string userInput = Utils.Utils.AcceptInformation();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine();
                    expensesTrackerApp.ListAvailableBudgets();
                    break;

                case "2":
                    Console.WriteLine();
                    CreateBudget();
                    break;

                case "3":
                    Console.WriteLine();
                    GetBudget();
                    break;

                case "4":
                    Console.WriteLine();
                    UpdateBudget();
                    break;

                case "5":
                    Console.WriteLine();
                    DeleteBudget();
                    break;

                case "6":
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

            if (userInput == "6")
            {
                StartApplicatioin();
            }

        }
    }
}

