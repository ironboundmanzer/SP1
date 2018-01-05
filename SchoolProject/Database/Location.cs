using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SchoolProject.Database
{
    class LocationImageClass
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string UpdatedBy { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string LocationImage { get; set; }
    }

    class Location
    {
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public string UpdatedBy { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }

    class LocationDAL
    {
        string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        SqlConnection con = null;
        SqlCommand cmd = null;

        public List<Location> GetLocation()
        {
            List<Location> lstlocation = new List<Location>();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("Select Location_Id,LocationName,Location_Address,Updated_By,Date,Time from tblLocation", con);
            try
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Location locobj = new Location();
                        locobj.LocationId = sdr["Location_Id"].ToString();
                        locobj.LocationName = sdr["LocationName"].ToString();
                        locobj.LocationAddress = sdr["Location_Address"].ToString();
                        locobj.UpdatedBy = sdr["Updated_By"].ToString();
                        locobj.Date = sdr["Date"].ToString();
                        locobj.Time = sdr["Time"].ToString();
                        lstlocation.Add(locobj);
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
            return lstlocation;
        }

        public LocationImageClass ShowLocation(string locationId)
        {
            LocationImageClass locobj = new LocationImageClass();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("Select LocationName,Location_Address,LocationImage from tblLocation where Location_Id=@locationId", con);
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("locationId", locationId);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        locobj.LocationName = sdr["LocationName"].ToString();
                        locobj.LocationAddress = sdr["Location_Address"].ToString();
                        locobj.LocationImage = sdr["LocationImage"].ToString();
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
            return locobj;
        }

        //public Location ShowLocation()
        //{
        //    Location locobj = new Location();
        //    con = new SqlConnection(cs);
        //    cmd = new SqlCommand("Select Location_Id,LocationName,Location_Address,Updated_By,Date from tblLocation", con);
        //    try
        //    {
        //        cmd.CommandType = CommandType.Text;
        //        con.Open();
        //        SqlDataReader sdr = cmd.ExecuteReader();
        //        if (sdr.HasRows)
        //        {
        //            while (sdr.Read())
        //            {
        //                locobj.LocationId = sdr["Location_Id"].ToString();
        //                locobj.LocationName = sdr["LocationName"].ToString();
        //                locobj.LocationAddress = sdr["Location_Address"].ToString();
        //                locobj.UpdatedBy = sdr["Updated_By"].ToString();
        //                locobj.Date = sdr["Date"].ToString();
        //                locobj.Time = sdr["Time"].ToString();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return locobj;
        //}

        public string GetLocationId()
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select MAX(Location_Id) from tblLocation",con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            string id = (string)cmd.ExecuteScalar();
            return id;
        }

        public void InsertLocation(LocationImageClass locobj)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_InsertLocation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@locationId",locobj.LocationId);
            cmd.Parameters.AddWithValue("@locationName",locobj.LocationName);
            cmd.Parameters.AddWithValue("@locationAddress",locobj.LocationAddress);
            cmd.Parameters.AddWithValue("@update_by",locobj.UpdatedBy);
            cmd.Parameters.AddWithValue("@date", locobj.Date);
            cmd.Parameters.AddWithValue("@time",locobj.Time);
            cmd.Parameters.AddWithValue("@limage", locobj.LocationImage);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void UpdateLocation(LocationImageClass locobj)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("usp_UpdateLocation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@locationId", locobj.LocationId);
            cmd.Parameters.AddWithValue("@locationName", locobj.LocationName);
            cmd.Parameters.AddWithValue("@locationAddress", locobj.LocationAddress);
            cmd.Parameters.AddWithValue("@limage", locobj.LocationImage);
            cmd.Parameters.AddWithValue("@update_by", locobj.UpdatedBy);
            //cmd.Parameters.AddWithValue("@date", locobj.Date);
            //cmd.Parameters.AddWithValue("@time", locobj.Time);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public void DeleteLocation(string locationId)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("delete from tblLocation where Location_Id=@locationId", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@locationId", locationId);
            con.Open();
            cmd.ExecuteNonQuery();
        }

        public int CountRegistrationType(string regtype)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select Count(StudentId) from tblStudentInfo where RegistrationType=@regType", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@regType", regtype);
            con.Open();
            int id = (int)cmd.ExecuteScalar();
            return id;
        }

        public string GetLocationNameByLocationId(string locationId)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Select LocationName from tblLocation where Location_Id =@locationId", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@locationId", locationId);
            con.Open();
            string locationName = (string)cmd.ExecuteScalar();
            return locationName;
        }
    }
}
