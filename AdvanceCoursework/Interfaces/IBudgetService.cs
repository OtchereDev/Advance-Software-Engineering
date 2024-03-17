using AdvanceCoursework.Models;

namespace AdvanceCoursework.Interfaces
{
	public interface IBudgetService
	{
        public Budget? CreateBudget(string month, int year, string userId);

        public bool DeleteBudget(string budgetID);

        public void AddBudgetItem(float amount, string categoryId, string budgetId, bool isExpense);

        public void RemoveBudgetItem(string budgetItemId, string budgetId);

        public void UpdateBudgetItem(string budgetItemId, string budgetId, float amount);

        public Budget GetBudgetById(string budgetId);

    }
}

