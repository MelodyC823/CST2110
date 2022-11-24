using System;
using System.Collections.Generic;
using System.Text;

namespace _2110.RestaurantDataAccess
{
    public interface IReadConfiguration
    {
        string GetConnectionString(string connectionString);
    }
}
