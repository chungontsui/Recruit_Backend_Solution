using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recruit.Repository
{
	public class Helper
	{
		public static string MaskingCCNumber(string CCNumber)
		{
			/*
			 According to:
			 https://www.pcicomplianceguide.org/whats-the-best-practice-for-masking-or-truncating-pan/
			 Mask PAN when displayed (the first six and last four digits are the maximum number of digits to be displayed)
			*/

			var maskedNumber = CCNumber;
			var charArray = CCNumber.ToCharArray();

			if (CCNumber.Length > 10)
			{
				
				List<char> MaskedList = new List<char>();
				for (int i = 0; i < charArray.Length; i++)
				{
					if ((i >= 0 && i < 6) || (i >= (charArray.Length - 4) && i < charArray.Length)) //First 6 and Last 4 not masked
					{
						MaskedList.Add(charArray[i]);
					}
					else
					{
						MaskedList.Add('X');
					}
				}
				maskedNumber = string.Concat(MaskedList);
			}
			else
			{
				//Masking All
				maskedNumber = string.Concat(charArray.Select(c => { return 'X'; }));
			}

			return maskedNumber;
		}
	}
}
