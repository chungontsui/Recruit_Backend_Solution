using System;
using System.Collections.Generic;
using System.Linq;
using Recruit.Data.Model;

namespace Recruit.Repository
{
	public class CustomerDetailDAO
	{
		private CustomerDetailsContext _context;
		public CustomerDetailDAO(CustomerDetailsContext context)
		{
			this._context = context;
		}

		public IEnumerable<CustomerDetail> GetAllCustomerDetails()
		{
			return _context.customerDetails;
		}

		public void AddCustomerDetail(CustomerDetail customerDetail)
		{
			_context.customerDetails.Add(customerDetail);
		}

		public CustomerDetail GetCustomerDetailById(int id)
		{
			return _context.customerDetails.Single<CustomerDetail>(c => c.Id.Equals(id));
		}
	}
}
