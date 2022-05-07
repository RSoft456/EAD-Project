using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EADProject.Models
{
    public class UserRepository
    {
        public string AddUser(User u)
        {
            string ConStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = BlogSpot; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();
            string querry2 = $"Select * from UserData where UserName = '{u.UserName}'";
            SqlCommand cmd2 = new SqlCommand(querry2, connection);
            SqlDataReader SDR = cmd2.ExecuteReader();
            while (SDR.Read())
            {
                
            }
            if (SDR.HasRows)
            {
                connection.Close();
                return "This User Name already exists";
            }
            else
            {
                connection.Close();
                connection.Open();
                string querry = $"Insert into UserData(UserName,Password,Email) values('{u.UserName}','{u.Password}','{u.Email}')";
                SqlCommand cmd = new SqlCommand(querry, connection);
                int insertdata = cmd.ExecuteNonQuery();
                connection.Close();
                return "Signed Up Successfully";
            }
        }
        public List<User> GetAllUsers()
        {
            List<User> data = new List<User>();
            string ConStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = BlogSpot; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();
            string querry = $"Select * from UserData";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader SDR = cmd.ExecuteReader();
            while (SDR.Read())
            {
                User obj = new User();
                obj.UserName = SDR.GetValue(1).ToString();
                obj.Password = SDR.GetValue(2).ToString();
                obj.Email = SDR.GetValue(3).ToString();
                data.Add(obj);
            }
            if (SDR.HasRows)
            {
                return data;
            }
            else
            {
                List<User> data2 = new List<User>();
                return data2;
            }
        }
        public User searchUser(User u)
        {
            User data = new User();
            string ConStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = BlogSpot; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            SqlConnection connection = new SqlConnection(ConStr);
            connection.Open();
            string querry = $"Select * from UserData where UserName='{u.UserName}' and Password='{u.Password}'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            SqlDataReader SDR = cmd.ExecuteReader();
            while (SDR.Read())
            {
                data.UserName = SDR.GetValue(1).ToString();
                data.Password = SDR.GetValue(2).ToString();
            }
            if (SDR.HasRows)
            {
                return data;
            }
            else
            {
                data.UserName = string.Empty;
                data.Password = string.Empty;
                return data;
            }
        }
    }
}
