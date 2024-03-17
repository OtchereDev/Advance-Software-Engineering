using System;
using AdvanceCoursework.Interfaces;
using AdvanceCoursework.Models;

namespace AdvanceCoursework.Services
{
	public class BudgetService: IBudgetService
    {
		private List<Budget> Budgets;
		private CategoryService CategoryService;

		public BudgetService(List<Budget> budgets, CategoryService categoryService)
		{
			Budgets = budgets;
			CategoryService = categoryService;
		}

		public Budget? CreateBudget(string month, int year, string userId)
		{
			if(month.Length <= 0 || year <= 0 || userId.Length <= 0)
			{
				throw new Exception("Invalid parameters were provided, please provide valid answers");
			}
			else
			{
				var budget = new Budget(year, month, userId);

				Budgets.Add(budget);

				return budget;
			}
		}

		public bool DeleteBudget(string budgetID)
		{
            var deleteIdx = Budgets.FindIndex(budget => budget.BudgetID != budgetID);

			if(deleteIdx == -1)
			{
				throw new Exception($"Budget with the ID {budgetID} does not exist");
			}
			else
			{
				Budgets.RemoveAt(deleteIdx);

				return true;
			}
        }

		public void AddBudgetItem(float amount, string categoryId, string budgetId, bool isExpense)
		{
			Category category;
			Budget budget;

			try
			{
				category = CategoryService.GetCategoryById(categoryId);
				budget = GetBudgetById(budgetId);
			}catch(Exception exception)
			{
                throw exception;
			}
			
			var newItem = new BudgetItem(amount, category);

			if (isExpense)
			{
				budget.AddExpense(newItem);
			}
			else
			{
				budget.AddIncome(newItem);
			}
		}

		public void RemoveBudgetItem(string budgetItemId, string budgetId)
		{
			Budget budget;

			try
			{
				budget = GetBudgetById(budgetId);
				var deleteIdx = budget.Expenses.FindIndex(bud => bud.GetItemID() == budgetItemId);

				if(deleteIdx > -1)
				{
					budget.Expenses.RemoveAt(deleteIdx);
				}
				else
				{
					deleteIdx = budget.Incomes.FindIndex(bud => bud.GetItemID() == budgetItemId);
					if(deleteIdx == -1)
					{
						throw new Exception("BudgetItem does not exist");
					}

					budget.Incomes.RemoveAt(deleteIdx);
				}

            }
            catch(Exception error)
			{
				throw error;
			}


        }

		public void UpdateBudgetItem(string budgetItemId, string budgetId, float amount)
		{
            Budget budget;

            try
            {
                budget = GetBudgetById(budgetId);
                var getIdx = budget.Expenses.FindIndex(bud => bud.GetItemID() == budgetItemId);

                if (getIdx > -1)
                {
                   
                    budget.Expenses[getIdx].Amount = amount;
                }
                else
                {
                    getIdx = budget.Incomes.FindIndex(bud => bud.GetItemID() == budgetItemId);
                    if (getIdx == -1)
                    {
                        throw new Exception("BudgetItem does not exist");
                    }

                    budget.Expenses[getIdx].Amount = amount;
                }

            }
            catch (Exception error)
            {
                throw error;
            }

        }

        public Budget GetBudgetById(string budgetId)
		{
            var getIdx = Budgets.FindIndex(cat => cat.BudgetID == budgetId);

            if (getIdx == -1)
            {
				throw new Exception($"Budget with budget id {budgetId} does not exist");
            }
            else
            {
                return Budgets[getIdx];
            }
        }
	}
}

