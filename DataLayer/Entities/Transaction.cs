using System;
using SQLite;
namespace DataLayer.Entities
{
	[Table ("Transaction")]
	public class Transaction
	{
		
		public Transaction()
		{
		}
		[PrimaryKey,AutoIncrement]
		public int Id{ get; set; }
		public string Documents { get; set; }
		
	}
}

