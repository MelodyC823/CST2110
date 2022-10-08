using System;
using System.Collections.Generic;
using System.Text;
using _2110_Sep2022;
using Microsoft.Data.SqlClient;
          
namespace Sept2022.SqlDataAccess
{
    public class EmployeeRepository
    {
        private readonly IReadConfiguration readConfiguration;

        public EmployeeRepository(IReadConfiguration readConfiguration)
        {
            this.readConfiguration = readConfiguration;
        }

        /// <summary>
        /// Assignment 1
        /// </summary>
        /// <param name="employee"></param>
        public void Add(Employee employee)
        {

        }

        /// <summary>
        /// Assignment 1
        /// </summary>
        /// <param name="employee"></param>
        public void Delete(Employee employee)
        {

        }

        /// <summary>
        /// Assignment 1
        /// </summary>
        /// <param name="employee"></param>
        public void Get(string idFilter)
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
