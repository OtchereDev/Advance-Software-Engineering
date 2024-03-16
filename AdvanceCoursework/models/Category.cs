using System;
namespace AdvanceCoursework.Models
{
	public class Category
	{
        private string Name { get; set; }
        private string CategoryID;

        public Category(string name)
        {
            Name = name;
            CategoryID = Guid.NewGuid().ToString();
        }

        public void View()
        {
            Console.WriteLine($"Category: {Name}");
        }

        public void ViewMain()
        {
            Console.WriteLine($"{Name}");
        }
    }
}

