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

        public void DeleteBudget() { }



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

