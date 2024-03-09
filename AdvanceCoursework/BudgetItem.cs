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
        public float Amount { get; private set; }
        public Category Category { get; private set; }

        // Constructor with itemID parameter
        public BudgetItem(string itemID, float amount, Category category)
        {
            ItemID = itemID;
            Amount = amount;
            Category = category;

        }

        // Overloaded constructor without itemID parameter
        public BudgetItem(float amount, Category category)
            : this(Guid.NewGuid().ToString(), amount, category)
        {
        }

        // Getter and setter methods for itemID (read-only)
        public string GetItemID()
        {
            return ItemID;
        }
    }
}
