using System;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography;

namespace AdvanceCoursework.Models
{
	public class Spending
	{
		public Category Category;
		public float Amount;

		public Spending(Category category, float amount)
		{
			Category = category;
			Amount = amount;
		}

		public void IncreaseAmount(float amount)
		{
			Amount += amount;
		}

    }
}

