﻿
using AdvanceCoursework.Models;

namespace AdvanceCoursework
{
    public class ExpensesTrackerApp
    {
        private List<Transaction> transactions;
        private List<Category> categories;
        private List<Budget> budgets;

        public ExpensesTrackerApp(string userId)
        {
            transactions = new List<Transaction>();
            categories = new List<Category>();
            budgets = new List<Budget>();

            // Creating BudgetItem objects for each category
            //BudgetItem groceriesItem1 = new BudgetItem(100, groceries);
            //BudgetItem utilitiesItem1 = new BudgetItem(50, utilities);
            //BudgetItem entertainmentItem1 = new BudgetItem(30, entertainment);
            //BudgetItem transportationItem1 = new BudgetItem(80, transportation);


            //budget1.AddExpense(groceriesItem1);
            //budget1.AddExpense(groceriesItem2);
            //budget1.AddExpense(groceriesItem3);
            //budget1.AddExpense(groceriesItem4);
            //budget1.AddExpense(utilitiesItem1);
            //budget1.AddExpense(utilitiesItem2);
            //budget1.AddExpense(utilitiesItem3);
            //budget1.AddExpense(entertainmentItem1);
            //budget1.AddExpense(entertainmentItem2);
            //budget1.AddExpense(entertainmentItem3);
            //budget1.AddExpense(transportationItem1);
            //budget1.AddExpense(transportationItem2);
            //budget1.AddExpense(transportationItem3);

            // Creating 20 transactions
            //Transaction transaction1 = new Transaction(TransactionType.Income, groceries, budget1, "Salary", false, DateTime.Now);
            //Transaction transaction2 = new Transaction(TransactionType.Expense, utilities, budget1, "Electricity bill", false, DateTime.Now);
            //Transaction transaction3 = new Transaction(TransactionType.Expense, groceries, budget2, "Grocery shopping", true, DateTime.Now);
            //Transaction transaction4 = new Transaction(TransactionType.Expense, entertainment, budget2, "Movie tickets", false, DateTime.Now);
            //Transaction transaction5 = new Transaction(TransactionType.Income, transportation, budget1, "Reimbursement", false, DateTime.Now);
            //Transaction transaction6 = new Transaction(TransactionType.Expense, groceries, budget1, "Dinner", false, DateTime.Now);
            //Transaction transaction7 = new Transaction(TransactionType.Expense, groceries, budget2, "Vegetables", false, DateTime.Now);
            //Transaction transaction8 = new Transaction(TransactionType.Expense, utilities, budget1, "Internet bill", true, DateTime.Now);
            //Transaction transaction9 = new Transaction(TransactionType.Income, transportation, budget2, "Fuel refund", false, DateTime.Now);
            //Transaction transaction10 = new Transaction(TransactionType.Expense, entertainment, budget2, "Concert tickets", false, DateTime.Now);
            //Transaction transaction11 = new Transaction(TransactionType.Expense, groceries, budget1, "Snacks", false, DateTime.Now);
            //Transaction transaction12 = new Transaction(TransactionType.Expense, transportation, budget2, "Bus fare", false, DateTime.Now);
            //Transaction transaction13 = new Transaction(TransactionType.Income, utilities, budget1, "Rent", false, DateTime.Now);
            //Transaction transaction14 = new Transaction(TransactionType.Expense, entertainment, budget2, "Netflix subscription", false, DateTime.Now);
            //Transaction transaction15 = new Transaction(TransactionType.Expense, groceries, budget2, "Fruits", false, DateTime.Now);
            //Transaction transaction16 = new Transaction(TransactionType.Expense, transportation, budget1, "Taxi fare", false, DateTime.Now);
            //Transaction transaction17 = new Transaction(TransactionType.Income, entertainment, budget2, "Freelance work", false, DateTime.Now);
            //Transaction transaction18 = new Transaction(TransactionType.Expense, transportation, budget1, "Car maintenance", true, DateTime.Now);
            //Transaction transaction19 = new Transaction(TransactionType.Expense, groceries, budget2, "Bakery items", false, DateTime.Now);
            //Transaction transaction20 = new Transaction(TransactionType.Expense, utilities, budget1, "Water bill", false, DateTime.Now);

            //transactions.Add(transaction13); transactions.Add (transaction14); transactions.Add (transaction15); transactions.Add(transaction20); transactions.Add(transaction16); transactions.Add (transaction17); transactions.Add(transaction18); transactions.Add(transaction19);
            //transactions.Add(transaction1); transactions.Add(transaction2); transactions.Add(transaction3); transactions.Add(transaction4); transactions.Add(transaction5);
            //transactions.Add(transaction6); transactions.Add(transaction7); transactions.Add(transaction8); transactions.Add(transaction9); 
            //transactions.Add(transaction10); transactions.Add(transaction11); transactions.Add(transaction12);

            

        }

        public void ViewRecentTransactions()
        {
            Console.WriteLine("Recent Transactions:\n");
            foreach (var transaction in transactions)
            {
                //Console.WriteLine($"Amount: {transaction.Amount}, Category: {transaction.Category.Name}, Date: {transaction.DateAndTime}");
            }
        }

        public void EnterNewTransaction(TransactionType transType, Category category, Budget budget, string note, bool recurring)
        {
            Transaction newTransaction = new Transaction(transType, category, budget, note, recurring);
            transactions.Add(newTransaction);
        }

        public void EditOrDeleteTransaction()
        {
            Console.WriteLine("Edit/Delete Transaction:\n");
            // Code to edit or delete transactions
        }

        public void ViewCategories()
        {
            Console.WriteLine("Categories:\n");
            foreach (var category in categories)
            {
                // Console.WriteLine(category.Name);
            }
        }

        public void EnterBudget()
        {
            Console.WriteLine("Enter Budget:\n");
            // Code to allow user to enter budget for each category
        }

        public void TrackProgress()
        {
            Console.WriteLine("Track Progress:\n");
            // Code to track spending against budget
        }
    }
}
