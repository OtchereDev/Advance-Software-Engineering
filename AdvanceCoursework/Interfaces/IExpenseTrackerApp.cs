using AdvanceCoursework.Models;

namespace AdvanceCoursework.Interfaces
{
    public interface IExpenseTrackerApp
    {
        public void ListAllCategories();

        public void AddCategory(string categoryName);

        public void UpdateCategory(string catId, string catName);

        public void DeleteCategory(string catId);

        public Budget? AddBudget(string month, int year);

        public void ListAvailableBudgets();

        public Budget? GetBudgetById(string budgetId);

        public void DeleteBudget(string budgetId);

        public void AddBudgetItem(string budgetId, float amount, string categoryId, bool isExpenses);

        public void DeletBudgetItem(string budgetItemId, string budgetId);

        public void UpdateBudgetItem(string budgetItemId, string budgetId, float amount);

        public void GetAllTransactions();

        public void GetAllOrderedTransaction();

        public void CreateTransaction(TransactionType transType, string catId, bool isRecurring, bool isToday, float amount, DateTime? dateTime, string? budgetId, string? note);

        public void DeleteTransaction(string transactionId);

        public void GetTransactionByID(string transId);

        public void UpdateTransaction(string transactionId, float amount);

    }
}

