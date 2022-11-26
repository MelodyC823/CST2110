using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _2110.CommandMsg
{
    public class Command
    {
        [Required]
        public CommandType CommandType;
    }
}
