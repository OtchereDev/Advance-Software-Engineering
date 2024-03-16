using System;
using AdvanceCoursework.Models;

namespace AdvanceCoursework.Services
{
	public class ExpenseTrackerApp
	{
        private List<Transaction> transactions;
        private List<Category> categories;
        private List<Budget> budgets;
        private static ExpensesTrackerApp instance;

        private ExpenseTrackerApp()
        {
            transactions = new List<Transaction>();
            categories = new List<Category>();
            budgets = new List<Budget>();
        }

        public static ExpensesTrackerApp GetInstance()
        {
            if (instance == null)
            {
                instance = new ExpensesTrackerApp();
            }
            return instance;
        }


	}
}

