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
        public float Amount { get; set; }
        public List<BudgetItem> Income { get; set; }
        public List<BudgetItem> Expenses { get; set; }
        public string UserID { get; set; }

        // Constructor with budgetID parameter
        public Budget(string budgetID, float amount, List<BudgetItem> income, List<BudgetItem> expenses, string userId)
        {
            BudgetID = budgetID;
            Amount = amount;
            Income = income;
            Expenses = expenses;
            UserID = userId;
        }

        // Overloaded constructor without budgetID parameter
        public Budget(float amount, List<BudgetItem> income, List<BudgetItem> expenses, string userId)
            : this(Guid.NewGuid().ToString(), amount, income, expenses, userId)
        {
        }

        // Getter and setter methods for budgetID (read-only)
        public string GetBudgetID()
        {
            return BudgetID;
        }
    }
}
