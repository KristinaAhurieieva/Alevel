using System;
using System.Collections;
using HomeWorkDevices.Enums;
using HomeWorkDevices.Models;
using HomeWorkDevices.Repositories;

namespace HomeWorkDevices.Services
{
    public class SortingService : IComparer<Devices>
    {
        public int Compare(Devices x, Devices y)
        {
            if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            return new CaseInsensitiveComparer().Compare(x.Category, y.Category);
        }
    }
}


