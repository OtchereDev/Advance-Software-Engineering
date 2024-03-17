using AdvanceCoursework.Models;

namespace AdvanceCoursework.Interfaces
{
	public interface ICategoryService
	{
        public bool AddCategory(string categoryName);

        public bool DeleteCategory(string categoryId);
         
        public bool UpdateCategory(string categoryId, string categoryName);
         
        public Category GetCategoryById(string categoryId);

    }
}

