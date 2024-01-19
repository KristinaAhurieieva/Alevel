using System;
using System.Collections;
using SweetGift.Models;
namespace SweetGift.Service
{
	public class SortingService : IComparer 
	{
		public int Compare(object x, object y)
		{
			if(x == null)
			{
				return -1;
			} else if(y==null)
			{
				return 1;
			}
			return new CaseInsensitiveComparer().Compare(((Sweet)x).Flavour, ((Sweet)y).Flavour);
		}
	}
}

