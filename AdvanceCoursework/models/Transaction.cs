using System;

public enum TransactionType
{
    Income,
    Expense
}

namespace AdvanceCoursework.Models
{
	public class Transaction
	{
        public string TransactionID { get; private set; }
        public TransactionType TransType { get; private set; }
        public Category Category { get; private set; }
        public Budget Budget { get; private set; }
        public string Note { get; private set; }
        public bool Recurring { get; private set; }
        public DateTime DateAndTime { get; private set; }

        // Constructor with transactionID parameter
        public Transaction(string transactionID, TransactionType transType, Category category, Budget budget, string? note, bool recurring, DateTime dateAndTime)
        {
            TransactionID = transactionID;
            TransType = transType;
            Category = category;
            Budget = budget;
            Note = note;
            Recurring = recurring;
            DateAndTime = dateAndTime;
        }

        // Overloaded constructor without transactionID parameter
        public Transaction(TransactionType transType, Category category, Budget budget, string? note, bool recurring, DateTime dateAndTime)
            : this(Guid.NewGuid().ToString(), transType, category, budget, note, recurring, dateAndTime)
        {
        }

        public Transaction(TransactionType transType, Category category, Budget budget, string note, bool recurring)
       : this(Guid.NewGuid().ToString(), transType, category, budget, note, recurring, DateTime.Now)
        {
        }

        public string GetTransactionID()
        {
            return TransactionID;
        }

        public string CheckRecur(bool Recur)
        {
            if (Recur)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        public void View()
        {
            Console.WriteLine($"TransactionID: {TransactionID}");
            Console.WriteLine($"Transaction Type: {TransType}");
            Category.View();
            Budget.ViewInline();
            Console.WriteLine($"Note: {Note} ");
            Console.WriteLine($"Recurring Status: {CheckRecur(Recurring)}");
            Console.WriteLine($"Transaction Time: {DateAndTime}");
        }

    }
}

