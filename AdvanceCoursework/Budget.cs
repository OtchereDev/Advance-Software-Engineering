using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCoursework
{
    internal class Budget
    {
        public string BudgetID { get; private set; }
        public string BudgetName { get; private set; }
        public float Amount { get; private set; }
        public List<BudgetItem>? Income;
        public List<BudgetItem>? Expenses;
        public string UserID { get; private set; }

        // Constructor with budgetID parameter
        public Budget(string budgetID, string budgetName, float amount, List<BudgetItem>? income, List<BudgetItem>? expenses, string userId)
        {
            BudgetID = budgetID;
            BudgetName = budgetName;
            Amount = amount;
            Income = income;
            Expenses = expenses;
            UserID = userId;
        }

        // Overloaded constructor without budgetID parameter
        public Budget(float amount, string budgetName, List<BudgetItem>? income, List<BudgetItem>? expenses, string userId)
            : this(Guid.NewGuid().ToString(), budgetName, amount, income, expenses, userId)
        {
        }

        public Budget(string budgetName, float amount, string userId)
        : this(Guid.NewGuid().ToString(), budgetName, amount, new List<BudgetItem>(), new List<BudgetItem>(), userId)
        {
        }



        // Getter and setter methods for budgetID (read-only)
        public string GetBudgetID()
        {
            return BudgetID;
        }

        public void AddIncome(BudgetItem item)
        {
            Income.Add(item);
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

        }
    }
}
