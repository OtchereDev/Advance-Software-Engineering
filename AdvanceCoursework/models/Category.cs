using AdvanceCoursework.Interfaces;

namespace AdvanceCoursework.Models
{
    public class Category : IDisplay
    {
        private string Name;
        private string CategoryID;

        public Category(string name)
        {
            Name = name;
            CategoryID = Guid.NewGuid().ToString();
        }

        public string GetID()
        {
            return CategoryID;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void View()
        {
            Console.WriteLine($"CatID {CategoryID}: {Name}");
        }

        public void ViewMain()
        {
            Console.WriteLine($"{Name}");
        }
    }
}
