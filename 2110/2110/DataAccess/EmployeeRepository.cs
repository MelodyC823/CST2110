using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace _2110.DataAccess
{
    public class EmployeeRepository
    {
        private readonly IReadConfiguration readConfiguration;
        public EmployeeRepository(IReadConfiguration readConfiguration)
        {
            this.readConfiguration = readConfiguration;
        }

        public void Add(Employee employee)
        {

        }

        public void Delete(Employee employee)
        {

        }

        public void Get (string idFilter)
        {

        }

        public void SelectEmployees()
        {

        }



        private SqlConnection GetConnection()
        {
            var connString = readConfiguration.GetConnectionString(EnvironmentSettings.DBEnvironment);
            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new Exception("Database Connection string not found");
            }

            var connection = new SqlConnection(connString);

            return connection;
        }
    }
}
