using System;
using System.Collections.Generic;
using System.Text;

namespace Sept2022.SqlDataAccess
{
    public interface IReadConfiguration
    {
        string GetConnectionString(string configName);
    }
}
