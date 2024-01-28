using System;
using System.Collections;
using HomeWorkSalad.Models;

namespace HomeWorkSalad.Service
{
	public class SortingVegetableService : IComparer
	{
        public int Compare(object x, object y)
        {
            if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            return new CaseInsensitiveComparer().Compare(((Vegetable)x).Weight, ((Vegetable)y).Weight);
        }
    }
}

