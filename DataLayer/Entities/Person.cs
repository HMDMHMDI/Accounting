using System;
using SQLite;

namespace DataLayer.Entities
{
	[Table("People")]
	public class Person
	{
		public Person()
		{
		}
		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }
		[MaxLength(20)]
		public string FName { get; set; }
		[MaxLength(20)]
		public string LName { get; set; }
		[MaxLength(20)]
		public string PhoneNumber { get; set; }
		[MaxLength(30)]
		public string ImageName { get; set; }
	}
}

