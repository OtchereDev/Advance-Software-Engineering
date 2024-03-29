﻿
namespace AdvanceCoursework.Models
{
	public class Budget
	{
        public string BudgetID { get; private set; }
        public float Amount { get; private set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public string UserID { get; private set; }

        public List<BudgetItem>? Incomes;
        public List<BudgetItem>? Expenses;

        // Overloaded constructor without budgetID parameter
        public Budget(int year,string month, string userId)
        {
            Incomes = new List<BudgetItem>();
            Expenses = new List<BudgetItem>();
            BudgetID = Guid.NewGuid().ToString();
            Year = year;
            Month = month;
            UserID = userId;
            Amount = 0;
        }

        // Constructor with budgetID parameter
        public Budget(int year, string userId, string month, List<BudgetItem>? income, List<BudgetItem>? expenses)
            :this(year, month, userId )
        {
            Incomes = income;
            Expenses = expenses;
        }

       

        // Getter and setter methods for budgetID (read-only)
        public string GetBudgetID()
        {
            return BudgetID;
        }

        public void AddIncome(BudgetItem item)
        {
            Incomes.Add(item);
        }

        public void AddExpense(BudgetItem item)
        {
            Expenses.Add(item);
        }

        // View Budget Details
        public void ViewInline()
        {
            Console.WriteLine($"BudgetID: {BudgetID}, Amount: {Amount} ");
            //Console.Write($" ");
        }

        public void View()
        {
            Console.WriteLine($"BudgetID: {BudgetID}");
            Console.WriteLine($"Amount: {Amount} ");
            Console.WriteLine($"Number of Income: {Incomes.Count()} ");
            Console.WriteLine($"Number of Expenses: {Expenses.Count()} ");
        }
    }
}

