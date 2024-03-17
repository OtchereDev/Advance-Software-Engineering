using AdvanceCoursework.Interfaces;
using AdvanceCoursework.Models;

namespace AdvanceCoursework.Services
{
	public class CategoryService : ICategoryService
	{
		private List<Category> Categories;

		public CategoryService(List<Category> categories)
		{
			Categories = categories;
		}

		public bool AddCategory(string categoryName)
		{
			if (categoryName.Length > 0)
			{
				var newCategory = new Category(categoryName);
				Categories.Add(newCategory);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool DeleteCategory(string categoryId)
		{
			var deleteIdx = Categories.FindIndex(cat => cat.GetID() == categoryId);

			if (deleteIdx == -1)
			{
				return false;
			}
			else
			{
				Categories.RemoveAt(deleteIdx);
				return true;
			}

		}

		public bool UpdateCategory(string categoryId, string categoryName)
		{
			if (categoryName.Length <= 0)
			{
				return false;
			}

			var updateIdx = Categories.FindIndex(cat => cat.GetID() == categoryId);

			if (updateIdx == -1)
			{
				return false;
			}
			else
			{
				var category = Categories[updateIdx];
				category.SetName(categoryName);
				return true;
			}
		}

		public Category GetCategoryById(string categoryId)
		{
			var getIdx = Categories.FindIndex(cat => cat.GetID() == categoryId);

			if (getIdx == -1)
			{
				throw new Exception("Category does not exists");
			}
			else
			{
				return Categories[getIdx];
			}
		}

	}
}

