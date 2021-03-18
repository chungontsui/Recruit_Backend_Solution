using NUnit.Framework;
using System;
using Recruit.Repository;
using Microsoft.EntityFrameworkCore;
using Recruit.Data.Model;
using System.Linq;
using System.Text.RegularExpressions;

namespace Recruit.Test
{
	
	public class DAOTest
	{
		//[Test]
		//public void FirstTest()
		//{
		//	Assert.That(1 == 1, "This is Right");
		//}

		private DbContextOptions<CustomerDetailsContext> DBOptions;

		public DAOTest()
		{
			var optionsBuilder = new DbContextOptionsBuilder<CustomerDetailsContext>();
			optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=RecruitDB;Integrated Security=True");
			DBOptions = optionsBuilder.Options;
		}

		[Test]
		public void TestAdd_GetCustomerDetail()
		{
			using (CustomerDetailsContext context = new CustomerDetailsContext(DBOptions))
			{
				CustomerDetailDAO _dao = new CustomerDetailDAO(context);
				var _customerDetails = _dao.GetAllCustomerDetails();
				int beforeAddCount = _customerDetails.Count();
				_dao.AddCustomerDetail(new CustomerDetail() { CreditCard = "1234567891234567", CVC = "123", ExpiryDate = new DateTime(2022, 11, 11), Name = "Tester" });
				_customerDetails = _dao.GetAllCustomerDetails();
				int afterAddCount = _customerDetails.Count();
				Assert.That(afterAddCount - beforeAddCount == 1, $"The difference in customer count before and after is not 1, but {afterAddCount - beforeAddCount}");
			}
				
		}

		[Test]
		public void TestFailing_AddCustomerDetail()
		{
			using(var context = new CustomerDetailsContext(DBOptions))
			{
				var failingCustomerDatail = new CustomerDetail()
				{
					CreditCard = "12p45678",
					CVC = "123",
					ExpiryDate = new DateTime(2022, 11, 11),
					Name = "Tester"
				};
				CustomerDetailDAO _dao = new CustomerDetailDAO(context);
				Assert.Throws(typeof(Exception), () =>
				{
					_dao.AddCustomerDetail(failingCustomerDatail);
				});
			}
		}
	}
}
