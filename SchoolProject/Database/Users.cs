using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;

namespace SchoolProject.Database
{
    class User
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string UpdatedBy { get; set; }
        public string Date { get; set; }
    }

    class Users
    {
       //string cs1 = " ";
        
        //string cs = @"Data Source=DESKTOP-Q3V3MJF;Initial Catalog=SchoolATT;Integrated Security=True";
        string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //string cs1 =ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;

        public string LoginUser(string name, string password)
        {
            string command = "Select UserId from tblUsers where UserId=@userId or UserName=@name and Password=@password";
            string userId = "";

            Users ulobj = new Users();
            string encyptpassword = ulobj.Encrypt(password);

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(command, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@userId", name);
            cmd.Parameters.AddWithValue("@password", encyptpassword);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    userId = sdr["UserId"].ToString();
                }
            }
            return userId;
        }

        public List<User> ShowUsers()
        {
            List<User> lstuser = new List<User>();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("select UserId,UserName,Password,UserType,UpdatedBy,Date from tblUsers", con);
            try
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        User userobj = new User();
                        userobj.UserId = sdr["UserId"].ToString();
                        userobj.UserName = sdr["UserName"].ToString();
                        userobj.Password = sdr["Password"].ToString();
                        userobj.UserType = sdr["UserType"].ToString();
                        userobj.UpdatedBy = sdr["UpdatedBy"].ToString();
                        userobj.Date = sdr["Date"].ToString();
                        lstuser.Add(userobj);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return lstuser;
        }

        public User ShowDataOnTextBox(string userid)
        {
            User userobj = new User();
            try
            {
                con = new SqlConnection(cs);
                cmd = new SqlCommand("Select UserName,Password from tblUser where UserId=@userid", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@userid", userid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    
                    while (sdr.Read())
                    {
                        userobj.UserName = sdr["UserName"].ToString();
                        userobj.Password = sdr["Password"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return userobj;
        }

        public string GetUserId()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select MAX(UserId) from tblUsers", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            string id = (string)cmd.ExecuteScalar();
            return id;
        }

        public string ReturnName(string id, string password)
        {
            string name = "";
            string encpass = Encrypt(password);
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select UserName from tblUsers where UserId=@id or UserName=@name and Password=@password", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", id);
            cmd.Parameters.AddWithValue("@password", encpass);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                name = sdr["UserName"].ToString();
            }
            return name;
        }

        public string ReturnId(string name, string password)
        {
            string UserId = "";
            string encpass = Encrypt(password);
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select UserId from tblUsers where UserName=@name or UserId=@id and Password=@password", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@id", name);
            cmd.Parameters.AddWithValue("@password", encpass);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                UserId = sdr["UserId"].ToString();
            }
            return UserId;
        }

        public void InsertUserData(User userobj)
        {
            string encryptPassword = Encrypt(userobj.Password);

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_InsertUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userobj.UserId);
            cmd.Parameters.AddWithValue("@name", userobj.UserName);
            cmd.Parameters.AddWithValue("@password", encryptPassword);
            cmd.Parameters.AddWithValue("@usertype", userobj.UserType);
            cmd.Parameters.AddWithValue("@updatedby",userobj.UpdatedBy );
            cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString().ToString());
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateUserData(User userobj)
        {
            string encryptPassword = Encrypt(userobj.Password);

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_UpdateUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userid", userobj.UserId);
            cmd.Parameters.AddWithValue("@name", userobj.UserName);
            cmd.Parameters.AddWithValue("@password", encryptPassword);
            cmd.Parameters.AddWithValue("@usertype", userobj.UserType);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteUserData(string id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Delete from tblUsers where UserId=@userid", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@userid", id);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public string Encrypt(string encryptString)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement    
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {      
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76      
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "0ram@1234xxxxxxxxxxtttttuuuuuiiiiio";  //we can change the code converstion key as per our requirement, but the decryption key should be same as encryption key    
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {      
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76      
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
