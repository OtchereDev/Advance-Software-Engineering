using System;
using AdvanceCoursework.Interfaces;
using AdvanceCoursework.Models;

namespace AdvanceCoursework.Services
{
	public class TransactionService: ITransactionService
	{
		private List<Transaction> Transactions;
		private CategoryService CategoryService;
		private BudgetService BudgetService;

		public TransactionService(List<Transaction> transactions, CategoryService categoryService, BudgetService budgetService )
		{
			Transactions = transactions;
			CategoryService = categoryService;
			BudgetService = budgetService;
		}

		public void AddTransaction(TransactionType transType, string catId, bool isRecurring, bool isToday, float amount, DateTime? dateTime, string? budgetId, string? note)
		{
			Transaction transaction;
			Category category;
			Budget budget = null;

			try
			{
				category = CategoryService.GetCategoryById(catId);
				if(budgetId != null)
				{

					budget = BudgetService.GetBudgetById(budgetId);
				}
			}
			catch(Exception error)
			{
				throw error;
			}

			if (isToday)
			{
				transaction = new Transaction(transType, category, isRecurring, amount, budget, note);
			}
			else
			{
				transaction = new Transaction(transType, category, isRecurring, (DateTime) dateTime, amount, budget, note);
			}

			Transactions.Add(transaction);
		}

		public bool DeleteTransaction(string transId)
		{
            var deleteIdx = Transactions.FindIndex(cat => cat.TransactionID == transId);

            if (deleteIdx == -1)
            {
                return false;
            }
            else
            {
                Transactions.RemoveAt(deleteIdx);
                return true;
            }
        }

		public void GetAllTransactions()
		{
			Console.WriteLine("Thes are all your transactions");
			foreach (Transaction trans in Transactions)
			{
				trans.View();
				Console.WriteLine("-------------------------------------------");
			}

		}

		public Transaction GetTransactionById(string transId)
		{
            var getIdx = Transactions.FindIndex(cat => cat.TransactionID == transId);

            if (getIdx == -1)
            {
                throw new Exception("Category does not exists");
            }
            else
            {
                return Transactions[getIdx];
            }
        }

		public void GetOrderedTransaction()
		{
            Console.WriteLine("Thes are all your transactions");
			foreach (Transaction trans in Transactions.OrderByDescending(x => x.TransactionDate))
            {
                trans.View();
                Console.WriteLine("-------------------------------------------");
            }
        }

		public bool UpdateTransaction(string transId, float amount)
		{
            var getIdx = Transactions.FindIndex(cat => cat.TransactionID == transId);

            if (getIdx == -1)
            {
                return false;
            }
            else
            {
                Transactions[getIdx].Amount = amount;
                return true;
            }
        }
	}
}

