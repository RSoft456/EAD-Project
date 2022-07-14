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
            //string ConStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = BlogSpotDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //SqlConnection connection = new SqlConnection(ConStr);
            //connection.Open();
            //string querry2 = $"Select * from UserData where UserName = '{u.UserName}'";
            //SqlCommand cmd2 = new SqlCommand(querry2, connection);
            //SqlDataReader SDR = cmd2.ExecuteReader();
            //while (SDR.Read())
            //{

            //}
            //if (SDR.HasRows)
            //{
            //    connection.Close();
            //    return "This User Name already exists";
            //}
            //else
            //{
            //    connection.Close();
            //    connection.Open();
            //    string querry = $"Insert into UserData(UserName,Password,Email) values('{u.UserName}','{u.Password}','{u.Email}')";
            //    SqlCommand cmd = new SqlCommand(querry, connection);
            //    int insertdata = cmd.ExecuteNonQuery();
            //    connection.Close();
            //    return "Signed Up Successfully";
            //}
            var db = new BlogSpotDatabaseContext();
            //string querry = $"select * FormatException UserData where UserName = { u.UserName}";
            var data = db.UserData.FirstOrDefault(p => p.UserName == u.UserName);
            if (data !=  null)
            {
                return "This User Name already exists";
            }
            else
            {
                var newUser = new UserDatum();
                newUser.UserName = u.UserName;
                newUser.Password = u.Password;
                newUser.Email = u.Email;
                db.UserData.Add(newUser);
                db.SaveChanges();
                return "Signed Up Successfully";
            }
        }
        public List<User> GetAllUsers()
        {
            var db = new BlogSpotDatabaseContext();
            var data = db.UserData.ToList();
            List<User> data2 = new List<User>();
            if (data != null)
            {
                foreach(var i in data)
                {
                    User obj = new User();
                    obj.UserName = i.UserName;
                    obj.Password = i.Password;
                    obj.Email = i.Email;
                    data2.Add(obj);
                }
                return data2;
            }
            else
            {
                List<User> data3 = new List<User>();
                return data3;
            }
            //List<User> data = new List<User>();
            //string ConStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = BlogSpotDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //SqlConnection connection = new SqlConnection(ConStr);
            //connection.Open();
            //string querry = $"Select * from UserData";
            //SqlCommand cmd = new SqlCommand(querry, connection);
            //SqlDataReader SDR = cmd.ExecuteReader();
            //while (SDR.Read())
            //{
            //    User obj = new User();
            //    obj.UserName = SDR.GetValue(1).ToString();
            //    obj.Password = SDR.GetValue(2).ToString();
            //    obj.Email = SDR.GetValue(3).ToString();
            //    data.Add(obj);
            //}
            //if (SDR.HasRows)
            //{
            //    return data;
            //}
            //else
            //{
            //    List<User> data2 = new List<User>();
            //    return data2;
            //}
        }
        public User searchUser(User u)
        {
            var db = new BlogSpotDatabaseContext();
            var data = db.UserData.FirstOrDefault(n  => n.UserName == u.UserName && n.Password == u.Password);
            User data2 = new User();
            if (data != null)
            {
                data2.UserName = data.UserName;
                data2.Password = data.Password;
                return data2;
            }           
            else
            {
                data2.UserName = string.Empty;
                data2.Password = string.Empty;
                return data2;
            }
            //User data = new User();
            //string ConStr = @"Data Source = (localdb)\ProjectsV13; Initial Catalog = BlogSpotDatabase; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            //SqlConnection connection = new SqlConnection(ConStr);
            //connection.Open();
            //string querry = $"Select * from UserData where UserName='{u.UserName}' and Password='{u.Password}'";
            //SqlCommand cmd = new SqlCommand(querry, connection);
            //SqlDataReader SDR = cmd.ExecuteReader();
            //while (SDR.Read())
            //{
            //    data.UserName = SDR.GetValue(1).ToString();
            //    data.Password = SDR.GetValue(2).ToString();
            //}
            //if (SDR.HasRows)
            //{
            //    return data;
            //}
            //else
            //{
            //    data.UserName = string.Empty;
            //    data.Password = string.Empty;
            //    return data;
            //}
        }
    }
}
