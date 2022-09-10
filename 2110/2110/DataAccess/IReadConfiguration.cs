using System;
using System.Collections.Generic;
using System.Text;

namespace _2110.DataAccess
{
    public interface IReadConfiguration
    {
        string GetConnectionString(string configName);
    }
}
