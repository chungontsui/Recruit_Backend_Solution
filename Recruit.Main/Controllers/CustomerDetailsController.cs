using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Recruit.Repository;
using Recruit.Data.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Recruit.Main.Controllers
{
	[Route("api/CustomerDetails")]
	[ApiController]
	public class CustomerDetailsController : ControllerBase
	{
		private CustomerDetailDAO _dao;
		public CustomerDetailsController(CustomerDetailsContext Context)
		{
			_dao = new CustomerDetailDAO(Context);
		}
		// GET: api/<CustomerDetailsController>
		[HttpGet]
		public IEnumerable<CustomerDetail> Get()
		{
			return _dao.GetAllCustomerDetails();
		}

		// GET api/<CustomerDetailsController>/5
		[HttpGet("{id}")]
		public CustomerDetail Get(int id)
		{
			return _dao.GetCustomerDetailById(id);
		}

		// POST api/<CustomerDetailsController>
		[HttpPost]
		public void Post(CustomerDetail customerDetail)
		{
			_dao.AddCustomerDetail(customerDetail);
		}

		// PUT api/<CustomerDetailsController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		// DELETE api/<CustomerDetailsController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
