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

		public (List<Spending>, List<Spending>, float, float) GetSpending(DateTime dateTime)
		{
			var startDate = new DateTime(dateTime.Year, dateTime.Month, 1);
			var endDate = new DateTime(dateTime.Year, dateTime.Month, 31);

			var incomes = new List<Spending>();
			var expenses = new List<Spending>();
			float incomeTotal = 0;
			float expenseTotal = 0;

			var spendings = Transactions.OrderByDescending(x => x.TransactionDate).Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate);

			foreach(Transaction transaction in spendings)
			{
				if(transaction.TransType == TransactionType.Expense)
				{
					var spending = expenses.FirstOrDefault(x=>x.Category.GetID() == transaction.Category.GetID());
					if (spending == null)
					{
						var sp = new Spending(transaction.Category, transaction.Amount);
						expenses.Add(sp);
					}
					else
					{
						spending.IncreaseAmount(transaction.Amount);
					}

					expenseTotal += transaction.Amount;

                }
				else
				{
                    var spending = incomes.FirstOrDefault(x => x.Category.GetID() == transaction.Category.GetID());
                    if (spending == null)
                    {
                        var sp = new Spending(transaction.Category, transaction.Amount);
                        incomes.Add(sp);
                    }
                    else
                    {
                        spending.IncreaseAmount(transaction.Amount);
                    }

					incomeTotal += transaction.Amount;
                }
			}

			return (incomes,expenses, incomeTotal, expenseTotal);
        }

        public (List<Transaction>, List<Transaction>, float, float) GetSpendingReport(DateTime startDate, DateTime endDate)
        {
            var incomes = new List<Transaction>();
            var expenses = new List<Transaction>();
            float incomeTotal = 0;
            float expenseTotal = 0;

            var spendings = Transactions.OrderByDescending(x => x.TransactionDate).Where(x => x.TransactionDate >= startDate && x.TransactionDate <= endDate);

            foreach (Transaction transaction in spendings)
            {
                if (transaction.TransType == TransactionType.Expense)
                {
                   expenses.Add(transaction);

                    expenseTotal += transaction.Amount;

                }
                else
                {
                   incomes.Add(transaction);
                   

                  incomeTotal += transaction.Amount;
                }
            }

            return (incomes, expenses, incomeTotal, expenseTotal);
        }
    }
}

