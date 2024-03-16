using AdvanceCoursework.Services;

namespace AdvanceCoursework;

class Program
{
    private static ExpenseTrackerApp expensesTrackerApp;
    private static string UserID;

    static void Main(string[] args)
    {
            StartApplicatioin();
    }

    private void DisplayMenu()
    {
        Console.WriteLine("What tab do you want to use:");
        Console.WriteLine("1. Spendings");
        Console.WriteLine("2. Transactions");
        Console.WriteLine("3. Categories");
        Console.WriteLine("4. Reports");
        Console.Write("Enter your choice: ");
    }

    private static void StartApplicatioin()
    {

        Console.WriteLine("Welcome to Spending Tracker\n");
        do
        {
            Console.WriteLine("Please enter your UserID:");
            UserID = Console.ReadLine();
            Console.WriteLine("\n");
        } while (UserID.Length <= 0);

        expensesTrackerApp = ExpenseTrackerApp.GetInstance(UserID);



    }
}

