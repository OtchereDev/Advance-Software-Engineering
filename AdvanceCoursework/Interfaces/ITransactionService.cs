using AdvanceCoursework.Models;

namespace AdvanceCoursework.Interfaces
{
    public interface ITransactionService
    {
        public void AddTransaction(TransactionType transType, string catId, bool isRecurring, bool isToday, float amount, DateTime? dateTime, string? budgetId, string? note);

        public bool DeleteTransaction(string transId);

        public void GetAllTransactions();

        public Transaction GetTransactionById(string transId);

        public void GetOrderedTransaction();

        public bool UpdateTransaction(string transId, float amount);

    }
}

