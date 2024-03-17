using AdvanceCoursework.Interfaces;
using AdvanceCoursework.Models;

namespace AdvanceCoursework.Services
{
    public class ExpenseTrackerApp : IExpenseTrackerApp
    {
        private List<Transaction> Transactions;
        private List<Category> Categories;
        private List<Budget> Budgets;
        private string UserId;

        private static ExpenseTrackerApp instance;
        private CategoryService categoryService;
        private BudgetService budgetService;
        private TransactionService transactionService;

        private ExpenseTrackerApp(string userId)
        {
            Transactions = new List<Transaction>();
            Categories = new List<Category>();
            Budgets = new List<Budget>();
            UserId = userId;

            //services
            categoryService = new CategoryService(Categories);
            budgetService = new BudgetService(Budgets, categoryService);
            transactionService = new TransactionService(Transactions, categoryService, budgetService);

            // Prepopulates the expense tracker with categories
            PreloadCategories();
        }

        public static ExpenseTrackerApp GetInstance(string userId)
        {
            if (instance == null)
            {
                instance = new ExpenseTrackerApp(userId);
            }
            return instance;
        }

        public void ListAllCategories()
        {
            Console.WriteLine("Categories Available Are:");
            foreach (Category category in Categories)
            {
                category.View();
            }
        }

        public void AddCategory(string categoryName)
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

        public Budget? AddBudget(string month, int year)
        {
            try
            {
                var response = budgetService.CreateBudget(month, year, UserId);
                if (response != null)
                {
                    Console.WriteLine("✅ Budget successfully created");
                }
                return response;

            }
            catch (Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
                return null;
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

        public Budget? GetBudgetById(string budgetId)
        {
            try
            {
                var budget = budgetService.GetBudgetById(budgetId);
                budget.View();

                return budget;

            }
            catch (Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
                return null;
            }
        }

        public void DeleteBudget(string budgetId)
        {
            try
            {
                budgetService.DeleteBudget(budgetId);
                Console.WriteLine($"✅ Successfully deleted budget");
            }
            catch (Exception error)
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

        public void GetAllTransactions()
        {
            transactionService.GetAllTransactions();
        }

        public void GetAllOrderedTransaction()
        {
            transactionService.GetOrderedTransaction();
        }

        public void CreateTransaction(TransactionType transType, string catId, bool isRecurring, bool isToday, float amount, DateTime? dateTime, string? budgetId, string? note)
        {
            try
            {
                transactionService.AddTransaction(transType, catId, isRecurring, isToday, amount, dateTime, budgetId, note);
                Console.WriteLine($"✅ Successfully created transaction");
            }
            catch (Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
            }
        }

        public void DeleteTransaction(string transactionId)
        {
            var response = transactionService.DeleteTransaction(transactionId);

            if (response)
            {
                Console.WriteLine($"✅ Successfully deleted transaction");

            }
            else
            {
                Console.WriteLine($"❌ Could not delete, transaction does not exist");
            }
        }

        public void GetTransactionByID(string transId)
        {
            try
            {
                var response = transactionService.GetTransactionById(transId);

            }
            catch (Exception error)
            {
                Console.WriteLine($"❌ {error.Message}");
            }

        }

        public void UpdateTransaction(string transactionId, float amount)
        {
            var response = transactionService.UpdateTransaction(transactionId, amount);

            if (response)
            {
                Console.WriteLine($"✅ Successfully update transaction");
            }
            else
            {
                Console.WriteLine($"❌ Could not update, transaction does not exist");
            }
        }

        public (List<Spending>, List<Spending>, float, float) SpendingListing(DateTime dateTime)
        {
            var response = transactionService.GetSpending(dateTime);


            Console.WriteLine($"✅ Successfully fetched spending listing");

            return response;
        }


        public void GenerateReport(DateTime startDate, DateTime endDate, string fileName)
        {
            var (incomes, expenses, incomeTotal, expenseTotal) = transactionService.GetSpendingReport(startDate, endDate);

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.WriteLine($"Report For Transactions Between {startDate.Day}/{startDate.Month}/{startDate.Year} - {endDate.Day}/{endDate.Month}/{endDate.Year}");

                    writer.WriteLine($"Transaction          Category        Note        Amount");
                    foreach (var income in incomes)
                    {
                        income.WriteDetailsToFile(writer);

                        // Add a separator between vehicles
                        writer.WriteLine(new string('-', 30));
                    }
                    foreach (var expense in expenses)
                    {
                        expense.WriteDetailsToFile(writer);

                        // Add a separator between vehicles
                        writer.WriteLine(new string('-', 30));
                    }
                    writer.WriteLine($"Total                                    £{incomeTotal - expenseTotal}");


                    Console.WriteLine($"✅ Report generated and saved to {fileName}");
                }
            }
            catch (IOException ioException)
            {
                Console.WriteLine($"❌ Error: An IO exception occurred while writing to the file. Details: {ioException.Message}");
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                Console.WriteLine($"❌ Error: Unauthorized access to the file. Details: {unauthorizedAccessException.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
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

