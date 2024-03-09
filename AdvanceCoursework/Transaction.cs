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


        // Getter and setter methods for transactionID (read-only)
        public string GetTransactionID()
        {
            return TransactionID;
        }

        // No setter for transactionID as it's read-only



    }
}
