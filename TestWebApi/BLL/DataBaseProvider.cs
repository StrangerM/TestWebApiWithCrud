using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApi.BLL
{
    public class DataBaseProvider
    {

        public  DataTable GetDataFromDbById(string sqlQuery, string connectionString, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }

                using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    if (sqlQuery.IndexOf(' ') == -1)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }

                    cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                    {
                        sqlDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public  DataTable Get(string query, string connectionString)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (query.IndexOf(' ') == -1)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                    }

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public  int Remove(string query, string connectionString, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand sqlCommand = new SqlCommand(query, connection))
                {
                    if (query.IndexOf(' ') == -1)
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                    }

                    sqlCommand.Parameters.AddRange(parameters);
                    return (int)sqlCommand.ExecuteScalar();  
                }
            }
        }

        public  DataTable Add(string query, string connectionString, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (query.IndexOf(' ') == -1)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    }
                      
                    command.Parameters.AddRange(parameters);

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                    {
                        sqlDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public DataTable Update(string query, string connectionString, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                   
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (query.IndexOf(' ') == -1)
                    {
                        command.CommandType = CommandType.StoredProcedure;
                    }
                      
                    command.Parameters.AddRange(parameters);

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command))
                    {
                        sqlDataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }
    }
}
