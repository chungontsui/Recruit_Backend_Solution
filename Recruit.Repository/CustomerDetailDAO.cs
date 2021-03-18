using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
			if(string.IsNullOrEmpty(Regex.Match(customerDetail.CreditCard, @"^\d*$").Value))
			{
				throw new Exception("Invalid Credit Card Number");
			}

			if(string.IsNullOrEmpty(Regex.Match(customerDetail.CVC, @"^\d*$").Value))
			{
				throw new Exception("Invalid CVC Number");
			}

			customerDetail.CreditCard = Helper.MaskingCCNumber(customerDetail.CreditCard);

			try
			{
				_context.customerDetails.Add(customerDetail);
				_context.SaveChanges();
			}
			catch (Exception e)
			{
				//Logging
				throw new Exception("Error Adding New Customer Details", e);
			}
		}

		public CustomerDetail GetCustomerDetailById(int id)
		{
			return _context.customerDetails.Single<CustomerDetail>(c => c.Id.Equals(id));
		}
	}
}
