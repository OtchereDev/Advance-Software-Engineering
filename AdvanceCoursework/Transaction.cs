using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TransactionType
{
    Income,
    Expense
}

namespace AdvanceCoursework
{
    internal class Transaction
    {
        public string TransactionID { get; private set; }
        public TransactionType TransType { get; set; }
        public Category Category { get; set; }
        public Budget Budget { get; set; }
        public string? Note { get; set; } // Making Note attribute optional
        public bool Recurring { get; set; }
        public DateTime DateAndTime { get; set; }

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

        // Getter and setter methods for transactionID (read-only)
        public string GetTransactionID()
        {
            return TransactionID;
        }

        // No setter for transactionID as it's read-only



    }
}
