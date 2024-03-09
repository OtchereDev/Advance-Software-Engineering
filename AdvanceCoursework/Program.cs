namespace AdvanceCoursework;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // private string UId = "et11234";

        Category catA = new Category(" Bill ");

        BudgetItem biA = new BudgetItem( 300, catA );

        Budget budA = new Budget( 3000, "et11234");

        Transaction transA = new Transaction( TransactionType.Income, catA, budA, "This is our first budget", true);




    }
}

