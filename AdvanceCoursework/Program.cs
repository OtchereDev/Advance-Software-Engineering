using AdvanceCoursework.Models;
using AdvanceCoursework.Services;

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
                DisplaySpendingTab();
                break;

            case "2":
                Console.WriteLine();
                // Transaction List Here;
                TransactionMenu();
                break;

            case "3":
                Console.WriteLine();
                // Category Menu Here;
                CategoryMenu();
                break;

            case "4":
                Console.WriteLine();
                // Report Menu Here;
                GenerateReport();
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
        expensesTrackerApp.UpdateCategory(catId, catName);
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

                if (uInput.ToLower() == "yes")
                {
                    CreatBudgetItem(response.BudgetID);
                }
                else if (uInput.ToLower() == "no")
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

        if (budget != null)
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
                else if (uInput == "2")
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

    private static void DisplayTransactionMenu()
    {
        Console.WriteLine("What action do you want to perform:");
        Console.WriteLine("1. List All Transaction");
        Console.WriteLine("2. Create A Transaction");
        Console.WriteLine("3. Get A Transaction");
        Console.WriteLine("4. Update A Transaction");
        Console.WriteLine("5. Delete A Transaction");
        Console.WriteLine("6. Return To Main Tabs");
        Console.Write("Enter your choice: ");
    }

    private static void CreateTransaction()
    {
        DateTime? transactionDate = null;
        string? budgetId;
        TransactionType transType;

        Utils.Utils.PrintMessage("Is this an expenses transaction (TRUE / FALSE)");
        bool isExpenses = Utils.Utils.AcceptBooleanInformation();

        if (isExpenses)
        {
            transType = TransactionType.Expense;
        }
        else
        {
            transType = TransactionType.Income;
        }

        Utils.Utils.PrintMessage("Provide category id for the category of the this expenses");
        expensesTrackerApp.ListAllCategories();
        string catId = Utils.Utils.AcceptInformation();

        Utils.Utils.PrintMessage("Do you want link this transaction to a budget? enter budget id for the budget");
        expensesTrackerApp.ListAvailableBudgets();
        budgetId = Utils.Utils.AcceptInformation();

        if (budgetId.Length == 0)
        {
            budgetId = null;
        }

        Utils.Utils.PrintMessage("Provide amount");
        float amount = Utils.Utils.AcceptFloatInformation();

        Utils.Utils.PrintMessage("Is this an recurring transaction (TRUE / FALSE)");
        bool isRecurring = Utils.Utils.AcceptBooleanInformation();

        Utils.Utils.PrintMessage("Is the transaction for Today (TRUE / FALSE)");
        bool isToday = Utils.Utils.AcceptBooleanInformation();

        if (!isToday)
        {
            Console.WriteLine("Enter a transaction date (e.g., MM/dd/yyyy):");
            transactionDate = Utils.Utils.AcceptDateInformation();
        }

        Utils.Utils.PrintMessage("Transaction Note: (optional)");
        string note = Utils.Utils.AcceptInformation();

        expensesTrackerApp.CreateTransaction(transType, catId, isRecurring, isToday, amount, transactionDate, budgetId, note);

    }

    private static void GetTransaction()
    {
        Utils.Utils.PrintMessage("Provide a transaction id:");
        string budId = Utils.Utils.AcceptInformation();
        expensesTrackerApp.GetTransactionByID(budId);
    }


    private static void DeleteTransaction()
    {
        Utils.Utils.PrintMessage("Provide a transaction id:");
        string budId = Utils.Utils.AcceptInformation();
        expensesTrackerApp.DeleteTransaction(budId);
    }

    private static void UpdateTransaction()
    {
        Utils.Utils.PrintMessage("Provide a transaction id:");
        string budId = Utils.Utils.AcceptInformation();

        Utils.Utils.PrintMessage("Provide updated amount");
        float amount = Utils.Utils.AcceptFloatInformation();

        expensesTrackerApp.UpdateTransaction(budId, amount);
    }

    private static void TransactionMenu()
    {
        while (true)
        {
            DisplayTransactionMenu();
            string userInput = Utils.Utils.AcceptInformation();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine();
                    expensesTrackerApp.GetAllOrderedTransaction();
                    Console.WriteLine();
                    break;

                case "2":
                    Console.WriteLine();
                    CreateTransaction();
                    Console.WriteLine();
                    break;

                case "3":
                    Console.WriteLine();
                    GetTransaction();
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine();
                    UpdateTransaction();
                    Console.WriteLine();
                    break;

                case "5":
                    Console.WriteLine();
                    DeleteTransaction();
                    Console.WriteLine();
                    break;

                case "6":
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine();
                    break;
            }

            if (userInput == "6")
            {
                StartApplicatioin();
            }

        }
    }

    private static void DisplaySpendingMenu(DateTime date)
    {
        DateTime prevMonth = AdjustDateMonth(date, -1);
        DateTime nextMonth = AdjustDateMonth(date, 1);

        Console.WriteLine("What action do you want to perform:");
        Console.WriteLine($"1. Previous Month ({prevMonth.Year}/{prevMonth.Month})");
        Console.WriteLine($"2. Next Month ({nextMonth.Year}/{nextMonth.Month})");
        Console.WriteLine("3. Return To Main Tabs");
        Console.Write("Enter your choice: ");
    }

    private static DateTime AdjustDateMonth(DateTime date, int increase)
    {
        DateTime newDate;
        if (increase == -1)
        {
            if (date.Month - 1 == 0)
            {
                newDate = new DateTime(date.Year - 1, 12, date.Day);
            }
            else
            {
                newDate = date.AddMonths(-1);
            }
        }
        else
        {
            if (date.Month + 1 == 13)
            {
                newDate = new DateTime(date.Year + 1, 1, date.Day);

            }
            else
            {
                newDate = date.AddMonths(1);
            }
        }

        return newDate;

    }

    private static void DisplaySpendingTab()
    {
        var date = DateTime.Now;
        DisplSpending(date);


        while (true)
        {
            Console.WriteLine("");
            DisplaySpendingMenu(date);
            string uInput = Utils.Utils.AcceptInformation();

            if (uInput == "1")
            {
                date = AdjustDateMonth(date, -1);
                DisplSpending(date);
            }
            else if (uInput == "2")
            {
                date = AdjustDateMonth(date, 1);
                DisplSpending(date);
            }
            else if (uInput == "3")
            {
                StartApplicatioin();
            }

        }
    }

    private static void DisplSpending(DateTime date)
    {

        var (incomes, expenses, incomeTotal, expenseTotal) = expensesTrackerApp.SpendingListing(date);
        Console.WriteLine($"Your spending from 01/{date.Month}/{date.Year} to  {date.Day}/{date.Month}/{date.Year}");

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Incomes:                     £{incomeTotal}");
        Console.ResetColor();
        var i = 1;
        foreach (Spending spending in incomes)
        {
            Console.WriteLine($"\t{i}.{spending.Category.GetName()}:            £{spending.Amount}");
            i++;
        }

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Expenses:                     £{expenseTotal}");
        Console.ResetColor();
        i = 1;
        foreach (Spending spending in expenses)
        {
            Console.WriteLine($"\t{i}. {spending.Category.GetName()}:            £{spending.Amount}");
            i++;
        }

        Console.WriteLine("---------------------------------------------------------------------");
        Console.ForegroundColor = (incomeTotal - expenseTotal) > 0 ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine($"Balance:                     £{incomeTotal - expenseTotal}");
        Console.ResetColor();
    }

    private static void GenerateReport()
    {
        Utils.Utils.PrintMessage("Enter a start date (e.g., MM/dd/yyyy):");
        DateTime startDate = Utils.Utils.AcceptDateInformation();

        Utils.Utils.PrintMessage("Enter a end date (e.g., MM/dd/yyyy):");
        DateTime endDate = Utils.Utils.AcceptDateInformation();

        string currentDirectory = Directory.GetCurrentDirectory();
        Utils.Utils.PrintMessage("Provide the name of the file the report should have");
        string fileName = Utils.Utils.AcceptInformation();

        expensesTrackerApp.GenerateReport(startDate, endDate, fileName);

        StartApplicatioin();
    }

}

