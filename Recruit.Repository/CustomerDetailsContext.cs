using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Recruit.Data.Model;

namespace Recruit.Repository
{
	public class CustomerDetailsContext : DbContext
	{
		public CustomerDetailsContext(DbContextOptions<CustomerDetailsContext> options) : base(options) { }

		public DbSet<CustomerDetail> customerDetails { get; set; }
	}
}
