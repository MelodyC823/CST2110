using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace _2110.DataAccess
{
    public class EmployeeRepository
    {
        private readonly IReadConfiguration readConfiguration;

        public EmployeeRepository()
        {
        }

        public EmployeeRepository(IReadConfiguration readConfiguration)
        {
            this.readConfiguration = readConfiguration;
        }

        //EMPLOYEE LIST
        public List<Employee> GetEmployee(string idFilter)
        {
            var employees = new List<Employee>();
            var sqlConnection = GetConnection();

            string sqlUpdate = $"SELECT * FROM STUDENT WHERE ID = '{idFilter}'";

            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);
            sqlConnection.Open();
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var employee = new Employee()
                {
                    ID = reader.GetString(0),
                    Name = reader.GetString(1)
                };
                employees.Add(employee);
            }
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return employees;

        }

    

    //ADD EMPLOYEE
    public void Add(Employee employee)
        {
            var sqlConnection = GetConnection();

            string sqlInsert = $"INSERT INTO Employee VALUES ('{employee.ID}','{employee.Name}')";

            SqlCommand sqlCommand = new SqlCommand(sqlInsert, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("Employee added");
        }

        //DELETE EMPLOYEE BY ID
        public void Delete(string id)
        {
            var sqlConnection = GetConnection();

            string sqldelete = $"DELETE FROM dbo.Employee WHERE ID = '{id}'";

            SqlCommand sqlCommand = new SqlCommand(sqldelete, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("Employee deleted");

        }

        //GET EMPLOYEE BY ID
        public Employee Get (string idFilter)
        {
            var sqlConnection = GetConnection();

            string sqlselect = $"SELECT * FROM dbo.Employee WHERE ID = '{idFilter}'";

            SqlCommand sqlCommand = new SqlCommand(sqlselect, sqlConnection);
             
            sqlConnection.Open();
                
            var reader = sqlCommand.ExecuteReader();

            Employee filterEmployee = new Employee();
            while (reader.Read())
            {
                filterEmployee = new Employee(reader["ID"].ToString(), reader["NAME"].ToString());

            }

            reader.Close();
            sqlConnection.Close();

            return filterEmployee;

        }

        //UPDATE EMPLOYEE
        public void Update(Employee employee)
        {
            var sqlConnection = GetConnection();

            string sqlUpdate = $"UPDATE Employee VALUES ('{employee.ID}','{employee.Name}')";

            SqlCommand sqlCommand = new SqlCommand(sqlUpdate, sqlConnection);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            Console.WriteLine("Employee updated");
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

