using _2110.RestaurantDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2110.CommandMsg
{
    public class RestaurantCommand : Command
    {

        [Required]
        public Restaurant Restaurant { get; set; }
    }
}
