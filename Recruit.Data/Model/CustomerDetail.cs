using System;
using System.Collections.Generic;
using System.Text;

namespace Recruit.Data.Model
{
	public class CustomerDetail
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string CreditCard { get; set; }
		public string CVC { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
