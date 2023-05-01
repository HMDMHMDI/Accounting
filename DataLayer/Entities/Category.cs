using System;
using SQLite;

namespace DataLayer.Entities
{
	[Table("Categories")]
	public class Category
	{
		public Category()
		{
		}

		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }
		public string Title { get; set; }
	}
}

