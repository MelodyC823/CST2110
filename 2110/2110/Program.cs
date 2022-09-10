
using _2110.DataAccess;
using System;
using Microsoft.Data.SqlClient;

namespace _2110
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTable();
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
