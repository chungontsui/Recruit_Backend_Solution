using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Recruit.Data.Model
{
	public class CustomerDetail
	{
		[Key]
		public int Id { get; set; }
		[Column(TypeName = "VARCHAR")]
		[StringLength(50)]
		public string Name { get; set; }
		[Column(TypeName = "VARCHAR")]
		[StringLength(50)]
		public string CreditCard { get; set; }
		[Column(TypeName = "VARCHAR")]
		[StringLength(10)]
		public string CVC { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
