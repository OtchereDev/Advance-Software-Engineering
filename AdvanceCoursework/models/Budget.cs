using System;
using System.Collections.Generic;

namespace AdvanceCoursework.Models
{
	public class Budget
	{
        public string BudgetID { get; private set; }
        public string BudgetName { get; private set; }
        public float Amount { get; private set; }
        public List<BudgetItem>? Incomes;
        public List<BudgetItem>? Expenses;
        public string UserID { get; private set; }

        // Overloaded constructor without budgetID parameter
        public Budget(float amount, string budgetName, string userId)
        {
            Incomes = new List<BudgetItem>();
            Expenses = new List<BudgetItem>();
            BudgetID = Guid.NewGuid().ToString();
            Amount = amount;
            BudgetName = budgetName;
            UserID = userId;
        }

        // Constructor with budgetID parameter
        public Budget(string budgetName, float amount, string userId, List<BudgetItem>? income, List<BudgetItem>? expenses)
            :this(amount, budgetName, userId )
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
            Console.WriteLine($"BudgetID: {BudgetName}, Amount: {Amount} ");
            //Console.Write($" ");
        }

        public void View()
        {
            Console.WriteLine($"BudgetID: {BudgetName}");
            Console.WriteLine($"Amount: {Amount} ");
            Console.WriteLine($"Number of Income: {Incomes.Count()} ");
            Console.WriteLine($"Number of Expenses: {Expenses.Count()} ");
        }
    }
}

