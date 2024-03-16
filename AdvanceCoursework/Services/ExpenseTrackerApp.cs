using System;
using AdvanceCoursework.Models;

namespace AdvanceCoursework.Services
{
	public class ExpenseTrackerApp
	{
        private List<Transaction> Transactions;
        private List<Category> Categories;
        private List<Budget> Budgets;
        private string UserId ;

        private static ExpensesTrackerApp instance;
        private CategoryService categoryService;
        private BudgetService budgetService;

        private ExpenseTrackerApp(string userId)
        {
            Transactions = new List<Transaction>();
            Categories = new List<Category>();
            Budgets = new List<Budget>();
            UserId = userId;

            //services
            categoryService = new CategoryService(Categories);
            budgetService = new BudgetService(Budgets, categoryService);

            // Prepopulates the expense tracker with categories
            PreloadCategories();
        }

        public static ExpensesTrackerApp GetInstance(string userId)
        {
            if (instance == null)
            {
                instance = new ExpensesTrackerApp(userId);
            }
            return instance;
        }

        public void ListAllCategories()
        {
            Console.WriteLine("Categories Available Are:");
            foreach(Category category in Categories)
            {
                category.View();
            }
        }

        public void AddCategories(string categoryName)
        {
            var response = categoryService.AddCategory(categoryName);

            if (response)
            {
                Console.WriteLine("✅ Category successfully added");
            }
            else
            {
                Console.WriteLine("❌ Please provide a valid category name");
            }
        }

        public void UpdateCategory(string catId, string catName)
        {
            var response = categoryService.UpdateCategory(catId, catName);

            if (response)
            {
                Console.WriteLine("✅ Category successfully updated");
            }
            else
            {
                Console.WriteLine("❌ There was an error updating the category. Either categories does not exists or the new category name cannot be empty");
            }
        }

        public void DeleteCategory(string catId)
        {
            var response = categoryService.DeleteCategory(catId);

            if (response)
            {
                Console.WriteLine("✅ Category successfully deleted");
            }
            else
            {
                Console.WriteLine("❌ There was an error updating the category. Either categories does not exists");
            }
        }

        public void AddBudget(string month, int year)
        {
            try
            {
                var response = budgetService.CreateBudget(month, year, UserId);
                if (response)
                {
                    Console.WriteLine("✅ Budget successfully created");
                }
                
            }
            catch(Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
            }
        }

        public void ListAvailableBudgets()
        {
            Console.WriteLine("Your Available budget are:");
            foreach (Budget budget in Budgets)
            {
                budget.ViewInline();
            }
        }

        public void GetBudgetById(string budgetId)
        {
            var budget = budgetService.GetBudgetById(budgetId);
            budget.View();
        }

        public void DeleteBudget(string budgetId)
        {
            try
            {
                budgetService.DeleteBudget(budgetId);
                Console.WriteLine($"✅ Successfully deleted budget");
            }
            catch(Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
            }
        }

        public void AddBudgetItem(string budgetId, float amount, string categoryId, bool isExpenses)
        {
            try
            {
                budgetService.AddBudgetItem(amount, categoryId, budgetId, isExpenses);
                Console.WriteLine($"✅ Successfully add budget item");
            }
            catch (Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
            }
        }

        public void DeletBudgetItem(string budgetItemId, string budgetId)
        {
            try
            {
                budgetService.RemoveBudgetItem(budgetItemId, budgetId);
                Console.WriteLine($"✅ Successfully deleted budget item");
            }
            catch (Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
            }
        }

        public void UpdateBudgetItem(string budgetItemId, string budgetId, float amount)
        {
            try
            {
                budgetService.UpdateBudgetItem(budgetItemId, budgetId, amount);
                Console.WriteLine($"✅ Successfully updated budget item");
            }
            catch (Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
            }
        }

        // utility methods
        private void PreloadCategories()
        {
            // Creating objects of the Category class
            Category groceries = new Category("Groceries");
            Category utilities = new Category("Utilities");
            Category entertainment = new Category("Entertainment");
            Category transportation = new Category("Transportation");
            Category salary = new Category("Salary");

            Categories.Add(groceries);
            Categories.Add(utilities);
            Categories.Add(entertainment);
            Categories.Add(transportation);
            Categories.Add(salary);
        }


	}
}

