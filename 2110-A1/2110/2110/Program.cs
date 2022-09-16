
using _2110.DataAccess;
using System;
using Microsoft.Data.SqlClient;

namespace _2110
{
    class Program
    {
        static void Main(string[] args)
        {

            EmployeeRepository emp = new EmployeeRepository(new ReadConfiguration());

            /*emp.Add(new Employee("12345", "Yifei"));
            emp.Add(new Employee("105", "Jenny"));
            emp.Add(new Employee("235", "William"));*/

            emp.Delete("105");

            Employee emp2 = emp.Get("12345");
            Console.WriteLine(emp2.Name);






        }

        public static void CreateTable()
        {
            var readConfig = new ReadConfiguration();
            var connString = readConfig.GetConnectionString(EnvironmentSettings.DBEnvironment);

            Console.WriteLine(connString);

            var sqlConnection = new SqlConnection(connString);

            string sqlStatement = "CREATE TABLE Employee(ID VARCHAR(30) NOT NULL, NAME VARCHAR(50) NOT NULL)";
            SqlCommand sqlCommand = new SqlCommand(sqlStatement, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
