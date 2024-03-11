namespace AdvanceCoursework;

class Program
{
    private static ExpensesTrackerApp expensesTrackerApp;
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");

        // private string UId = "et11234";

        Category catA = new Category(" Bill ");

        BudgetItem biA = new BudgetItem( 300, catA );

        Budget budA = new Budget("March Budget", 3000, "et11234");

        Transaction transA = new Transaction( TransactionType.Income, catA, budA, "This is our first budget", true);

        //transA.View();

        {
            // Creating an Instance of the Expenses Tracker App
            expensesTrackerApp = new ExpensesTrackerApp();

            StartApplicatioin();

        }
    }

    private static void StartApplicatioin()
    {

        // Main Program Start Here

        // Main Menu
        Console.WriteLine("Welcome to Teams Expences Calculator ");
        Console.WriteLine("Select to continue as:");
        Console.WriteLine("1. User Menu");
        Console.WriteLine("2. Admin Menu");
        Console.WriteLine("3. Retun to main menu");
        Console.WriteLine("0. Exit");

        Console.WriteLine();



    }
}

