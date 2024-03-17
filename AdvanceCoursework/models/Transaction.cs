using System;
using AdvanceCoursework.Interfaces;

public enum TransactionType
{
    Income,
    Expense
}

namespace AdvanceCoursework.Models
{
    public class Transaction: IDisplay
    {
        public string TransactionID { get; private set; }
        public TransactionType TransType { get; private set; }
        public Category Category { get; private set; }
        public Budget? Budget { get; private set; }
        public string? Note { get; private set; }
        public bool Recurring { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public float Amount {get; set;}

        // Constructor with transactionID parameter
        public Transaction(TransactionType transType, Category category, bool recurring, DateTime dateAndTime, float amount, Budget? budget, string? note)
        {
            TransactionID = Guid.NewGuid().ToString();
            TransType = transType;
            Category = category;
            Budget = budget;
            Note = note;
            Recurring = recurring;
            TransactionDate = dateAndTime;
            Amount = amount;
        }


        public Transaction(TransactionType transType, Category category, bool recurring,float amount, Budget? budget, string? note)
       : this(transType, category, recurring,  DateTime.Now, amount, budget, note)
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
            Budget?.ViewInline();
            Console.WriteLine($"Note: {Note} ");
            Console.WriteLine($"Recurring Status: {CheckRecur(Recurring)}");
            Console.WriteLine($"Transaction Time: {TransactionDate}");
        }

        public virtual void WriteDetailsToFile(StreamWriter writer)
        {
            var dir = TransactionType.Expense == TransType ? "-" : "+";
            writer.WriteLine($"{TransactionDate.Date}/{TransactionDate.Month}/{TransactionDate.Year}        {Category.GetName()}    {Note}      {dir}£{Amount}");
        }

    }
}
