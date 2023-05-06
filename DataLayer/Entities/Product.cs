using SQLite;
using System;
namespace DataLayer.Entities
{
	[Table("Products")]

	public class Product
	{
		public Product()
		{
		}
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		[MaxLength(20)]
		public string Name { get; set; }
		public string Price { get; set; }
		public string Count { get; set; }

		public int CategoryId { get; set; }
	}
}

