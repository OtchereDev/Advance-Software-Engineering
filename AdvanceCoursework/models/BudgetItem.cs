using AdvanceCoursework.Interfaces;

namespace AdvanceCoursework.Models
{
    public class BudgetItem : IDisplay
    {
        public string ItemID;
        public float Amount;
        public Category Category { get; private set; }

        public BudgetItem(float amount, Category category)
        {
            ItemID = Guid.NewGuid().ToString();
            Amount = amount;
            Category = category;
        }

        // Getter and setter methods for itemID (read-only)
        public string GetItemID()
        {
            return ItemID;
        }

        public void View()
        {
            Console.WriteLine($"{Category.GetName()}: {Amount}");
        }
    }
}
