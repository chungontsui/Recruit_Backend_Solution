using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using Recruit.Repository;

namespace Recruit.Test
{
	public class MiscTests
	{
		[TestCase("1234567891234567", "123456XXXXXX4567", Description = "Full sixteen digit number")]
		[TestCase("123456789", "XXXXXXXXX", Description = "Less than 10 digits")]
		[Test]
		public void TestMasking(string input, string expectedOutput)
		{
			var maskedNumber = Helper.MaskingCCNumber(input);
			Assert.That(maskedNumber.Equals(expectedOutput), $"Expected Masked Number of {expectedOutput} but actual: {maskedNumber}");
		}
	}
}
