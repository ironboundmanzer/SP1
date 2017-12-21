﻿
//namespace SchoolProject.Database
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SchoolProject.Database
{
    class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }
        public string ClassTeacher { get; set; }
        public string ClassTeacherContactNo { get; set; }
        public string FatherName { get; set; }
        public string GuardianName { get; set; }
        public string GuardianContactNo { get; set; }
        public string HomeAddress { get; set; }
        public string SiblingInformation { get; set; }
        public string EnrollmentYear { get; set; }
        public string JoinedSchoolDate { get; set; }
        public string BloodGroup { get; set; }
        public string Warnings { get; set; }
        public string Notes { get; set; }
        public string AadharNo { get; set; }
        public string StudentPhoto { get; set; }
    }

    //  this class Show Student Data on DataGridView
    class StudentforShow
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string RollNo { get; set; }
        public string EnrollmentYear { get; set; }
        public string AadharNo { get; set; }
    }

    class StudentDAL
    {
        string cs = @"Data Source=DESKTOP-Q3V3MJF\MEGMASQLSERVER;Initial Catalog=School;Integrated Security=True";
        SqlConnection con = null;
        SqlCommand cmd = null;

        //  One Image Show
        string img;
        public string ShowStudentImage(string studentid)
        {
            con = new SqlConnection(cs);
            cmd = new SqlCommand("Select StudentPhoto from tblStudentInfo where StudentId=@id", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@id", studentid);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Student std = new Student();
                    img = sdr["StudentPhoto"].ToString();
                }
            }
            return img;
        }

        // Show student Data on DataGridView
        public List<StudentforShow> ShowStudent()
        {
            List<StudentforShow> lststudent = new List<StudentforShow>();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("Select StudentId,Name,Gender,DOB,Class,Section,RollNo,EnrollmentYear,AadharNo from tblStudentInfo", con);
            try
            {
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        // StudentId,Name,Gender,DOB,Class,Section,RollNo,EnrollmentYear,AadharNo
                        StudentforShow std = new StudentforShow();
                        std.StudentId = sdr["StudentId"].ToString();
                        std.Name = sdr["Name"].ToString();
                        std.Gender = sdr["Gender"].ToString();
                        std.DOB = sdr["DOB"].ToString();
                        std.Class = sdr["Class"].ToString();
                        std.Section = sdr["Section"].ToString();
                        std.RollNo = sdr["RollNo"].ToString();
                        std.EnrollmentYear = sdr["EnrollmentYear"].ToString();
                        std.AadharNo = sdr["AadharNo"].ToString();
                        lststudent.Add(std);
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
            return lststudent;
        }

        // Find Maximum StudentId
        public string GetId()
        {
            con = new SqlConnection(cs);
            cmd = new SqlCommand("select max(substring(StudentId,5,4)) as studentid from tblStudentInfo", con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            string id = (string)cmd.ExecuteScalar();
            return id;
        }

        // Student Registrationg
        public void StudentRegistration(Student std)
        {
            try
            {
                con = new SqlConnection(cs);
                cmd = new SqlCommand("usp_InsertStudentRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentId", std.StudentId);
                cmd.Parameters.AddWithValue("@name", std.Name);
                cmd.Parameters.AddWithValue("@gender", std.Gender);
                cmd.Parameters.AddWithValue("@dob", std.DOB);
                cmd.Parameters.AddWithValue("@class", std.Class);
                cmd.Parameters.AddWithValue("@section", std.Section);
                cmd.Parameters.AddWithValue("@rollNo", std.RollNo);
                cmd.Parameters.AddWithValue("@classTeacher", std.ClassTeacher);
                cmd.Parameters.AddWithValue("@classTeacherContactNo", std.ClassTeacherContactNo);
                cmd.Parameters.AddWithValue("@fatherName", std.FatherName);
                cmd.Parameters.AddWithValue("@guardianName", std.GuardianName);
                cmd.Parameters.AddWithValue("@guardianContactNo", std.GuardianContactNo);
                cmd.Parameters.AddWithValue("@homeAddress", std.HomeAddress);
                cmd.Parameters.AddWithValue("@siblingInformation", std.SiblingInformation);
                cmd.Parameters.AddWithValue("@joinedSchoolDate", std.JoinedSchoolDate);
                cmd.Parameters.AddWithValue("@bloodGroup", std.BloodGroup);
                cmd.Parameters.AddWithValue("@notes", std.Notes);
                cmd.Parameters.AddWithValue("@aadharNo", std.AadharNo);
                cmd.Parameters.AddWithValue("@studentPhoto", std.StudentPhoto);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }

        //  Show Student Data on Textbox
        public Student ShowDataOnTextBox(string studentid)
        {
            Student std = new Student();
            con = new SqlConnection(cs);
            cmd = new SqlCommand("Select * from tblStudentInfo where StudentId=@studentId", con);
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@studentId", studentid);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        std.Name = sdr["Name"].ToString();
                        std.RollNo = sdr["RollNo"].ToString();
                        std.DOB = sdr["DOB"].ToString();
                        std.Class = sdr["Class"].ToString();
                        std.BloodGroup = sdr["BloodGroup"].ToString();
                        std.HomeAddress = sdr["HomeAddress"].ToString();
                        std.SiblingInformation = sdr["SiblingInformation"].ToString();
                        std.ClassTeacher = sdr["ClassTeacher"].ToString();
                        std.ClassTeacherContactNo = sdr["ClassTeacherContactNo"].ToString();
                        std.FatherName = sdr["FatherName"].ToString();
                        std.Gender = sdr["Gender"].ToString();
                        std.AadharNo = sdr["AadharNo"].ToString();
                        std.Section = sdr["Section"].ToString();
                        std.GuardianName = sdr["GuardianName"].ToString();
                        std.GuardianContactNo = sdr["GuardianContactNo"].ToString();
                        std.JoinedSchoolDate = sdr["JoinedSchoolDate"].ToString();
                        std.Notes = sdr["Notes"].ToString();
                        std.StudentPhoto = sdr["StudentPhoto"].ToString();
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
            return std;
        }

        //  Student Data Update and Save
        public void StudentUpdateAndSave(Student std)
        {
            try
            {
                con = new SqlConnection(cs);
                cmd = new SqlCommand("usp_UpdateOrSave", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentId", std.StudentId);
                cmd.Parameters.AddWithValue("@name", std.Name);
                cmd.Parameters.AddWithValue("@gender", std.Gender);
                cmd.Parameters.AddWithValue("@dob", std.DOB);
                cmd.Parameters.AddWithValue("@class", std.Class);
                cmd.Parameters.AddWithValue("@section", std.Section);
                cmd.Parameters.AddWithValue("@rollNo", std.RollNo);
                cmd.Parameters.AddWithValue("@classTeacher", std.ClassTeacher);
                cmd.Parameters.AddWithValue("@classTeacherContactNo", std.ClassTeacherContactNo);
                cmd.Parameters.AddWithValue("@fatherName", std.FatherName);
                cmd.Parameters.AddWithValue("@guardianName", std.GuardianName);
                cmd.Parameters.AddWithValue("@guardianContactNo", std.GuardianContactNo);
                cmd.Parameters.AddWithValue("@homeAddress", std.HomeAddress);
                cmd.Parameters.AddWithValue("@siblingInformation", std.SiblingInformation);
                cmd.Parameters.AddWithValue("@joinedSchoolDate", std.JoinedSchoolDate);
                cmd.Parameters.AddWithValue("@bloodGroup", std.BloodGroup);
                cmd.Parameters.AddWithValue("@notes", std.Notes);
                cmd.Parameters.AddWithValue("@aadharNo", std.AadharNo);
                cmd.Parameters.AddWithValue("@studentPhoto", std.StudentPhoto);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }

        // Student Data Delete By StudentId
        public void StudentDelete(string studentId)
        {
            try
            {
                con = new SqlConnection(cs);
                cmd = new SqlCommand("usp_DeleteStudentInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentId", studentId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }
        }

    }
}
