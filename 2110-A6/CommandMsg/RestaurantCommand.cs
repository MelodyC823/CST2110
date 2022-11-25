using _2110.RestaurantDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2110.CommandMsg
{
    public class RestaurantCommand : Command
    {
        public Restaurant Restaurant { get; set; }
    }
}
