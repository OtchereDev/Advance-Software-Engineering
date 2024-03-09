using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCoursework
{
    internal class BudgetItem
    {
        public string ItemID { get; private set; }
        public float Amount { get; set; }
        public Category Category { get; set; }
        public string BudgetID { get; set; }

        // Constructor with itemID parameter
        public BudgetItem(string itemID, float amount, Category category, string budgetID)
        {
            ItemID = itemID;
            Amount = amount;
            Category = category;
            BudgetID = budgetID;
        }

        // Overloaded constructor without itemID parameter
        public BudgetItem(float amount, Category category, string budgetID)
            : this(Guid.NewGuid().ToString(), amount, category, budgetID)
        {
        }

        // Getter and setter methods for itemID (read-only)
        public string GetItemID()
        {
            return ItemID;
        }
    }
}
