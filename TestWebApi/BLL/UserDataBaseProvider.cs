using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.BLL
{
    public class UserDataBaseProvider
    {

        public Users UserAdd(string firstName, string lastName, long phone, string email, int roleId)
        {
            string query = "sp_Users_Add";

            DataBaseProvider provider = new DataBaseProvider();
            DataTable table = new DataTable();

            try
            {
                table = provider.Add(query, Startup.ConnectionString, new System.Data.SqlClient.SqlParameter("@firstName", firstName),
                                                       new System.Data.SqlClient.SqlParameter("@lastName", lastName),
                                                       new System.Data.SqlClient.SqlParameter("@phone", phone),
                                                       new System.Data.SqlClient.SqlParameter("@email", email),
                                                       new System.Data.SqlClient.SqlParameter("@roleId", roleId));
            } catch (Exception ex){}

            if (table.Rows.Count == 0)
            {
                return null;
            }
            return GetUser(table.Rows[0]);
        }

        public bool UserRemove(int id)
        {
            string query = "sp_Users_Remove";
            DataBaseProvider provider = new DataBaseProvider();
            DataTable table = new DataTable();

            try
            {
                table = provider.Remove(query, Startup.ConnectionString, new System.Data.SqlClient.SqlParameter("@id", id));
            }
            catch (Exception ex)
            {

            }

            if (table.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        public Users GetUser(DataRow row)
        {
            return new Users()
            {
                Id = Convert.ToInt32(row["Id"]),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Phone = Convert.ToInt64(row["Phone"]),
                Email = row["Email"].ToString(),
                RoleId = Convert.ToInt32(row["RoleId"]),
                Status = Convert.ToBoolean(row["Status"]),
                Date = Convert.ToDateTime(row["Date"])
            };
        }

        public List<Users> GetUsers(DataTable table)
        {
            List<Users> users = new List<Users>();

            foreach (DataRow row in table.Rows)
            {
                users.Add(GetUser(row));
            }

            return users;
        }
    }
}
