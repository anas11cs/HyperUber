using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.IO;


namespace WebApplication4.Models
{
    public class DataAccessLayer
    {
        public static string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\source\repos\FinalProject\WebApplication4\App_Data\aspnet-WebApplication4-20191125061932.mdf;Initial Catalog=aspnet-WebApplication4-20191125061932;Integrated Security=True";
        //Register & Login
        public static bool UserRegistrationVerification(String cnic)
        {
            SqlDataReader reader = null;
            String queryString = "select Cnic from People Where People.Cnic='"+ cnic+"'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                string seenisee = "";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    seenisee = (string)reader["Cnic"];
                }
                if (seenisee.Equals(""))
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        
        public static bool DriverRegistrationVerification(String PhoneNo)
        {
            SqlDataReader reader = null;
            String queryString = "select PhoneNo from Drivers Where Drivers.PhoneNo='" + PhoneNo + "'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                string seenisee = "";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    seenisee = (string)reader["PhoneNo"];
                }
                if (seenisee.Equals(""))
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return false;
        }

        public static bool PeopleRegister(String Cnic, String Name, String Password, String PhoneNo, String Email)
        {
            if (UserRegistrationVerification(Cnic) == true)
            {
                SqlDataReader reader = null;
                //  RETURNS TRUE IF REGISTRATION SUCCESSFUL
                String queryString = "Insert Into People (Cnic,Name,Password,PhoneNo,PaymentBalance,Email)" +
                "Values('" + Cnic + "','" + Name + "','" + Password + "','" + PhoneNo + "',0,'" + Email + "')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();
                    if(reader!=null)
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public static bool DriverRegister(String Name,String Email,String Address,String Password,String PhoneNo,String Cnic,int YearsOfExperience)
        {// RETURNS TRUE IF REGISTRATION SUCCESSFUL
            if (DriverRegistrationVerification(PhoneNo)==true)
            {
                SqlDataReader reader = null;
                String queryString = "Insert Into Drivers (PhoneNo,Name,Email,Address,NumberPlate,Cnic,Rating,Paymentbalance,FineAmount,YearsOfExperience,Password)" +
                "Values('" + PhoneNo + "','" + Name + "','" + Email + "','" + Address + "',NULL,'" + Cnic
                + "',0,0,0," + YearsOfExperience + ",'" + Password + "')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();
                    if (reader != null)
                        return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public static bool UserLogin(String Email,String Password)
        {
            if ((!Email.Equals(null))&&(!Password.Equals(null)))
            {
                SqlDataReader reader = null;
                String queryString = "select Cnic from People Where People.Email='" + Email + "'AND People.Password='" + Password + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    string seenisee="";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       seenisee = (string)reader["Cnic"];
                    }
                    if(seenisee.Equals(""))
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DriverLogin(String Email, String Password)
        {
            if ((!Email.Equals(null)) && (!Password.Equals(null)))
            {
                SqlDataReader reader = null;
                String queryString = "select PhoneNo from Drivers Where Drivers.Email='" + Email + "'AND Drivers.Password='" + Password + "'";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    string seenisee = "";
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        seenisee = (string)reader["PhoneNo"];
                    }
                    if (seenisee.Equals(""))
                    {
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        // ADD CAR
        public static bool VerifyCar(String NumberPlate,String Cnic)
        {
            String queryString = "select NumberPlate from Cars Where Cars.NumberPlate='" + NumberPlate + "'AND Cars.Cnic='" + Cnic + "'";
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                string seenisee = "";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    seenisee = (string)reader["NumberPlate"];
                }
                if (seenisee.Equals(""))
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            return false;
        }
        public static bool AddCar(String NumberPlate,String Name , int Model ,String Make ,double PetrolInLitres,double DrivenInKms ,String Cnic,int EngineCC )
        {
                SqlDataReader reader = null;
                String queryString = "Insert Into Cars (NumberPlate,Name , Model ,Make ,PetrolInLitres,DrivenInKms,Rating ,Cnic,EngineCC)" +
"Values('" + NumberPlate + "','" + Name + "'," + Model + ",'" + Make + "'," + PetrolInLitres + "," + DrivenInKms
+ ",0,'" + Cnic + "'," + EngineCC +")";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    con.Open();
                    reader = cmd.ExecuteReader();
                    if (reader != null)
                        return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return false;
        }
        public static List<string> ShowCarsFromDataBase()
        {
            String queryString = "select Cars.Name from Cars";
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                List<string> seenisee = new List<string>();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    seenisee.Add((string)reader["Name"]);
                    
                }
                if (seenisee.Count==0)
                {
                    return null;
                }
                else
                {
                    return seenisee;

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
            finally
            {
                con.Close();
            }
            return null;
        }
        // REMOVE CAR,DRIVER,PERSON
        public static bool RemoveCar(String NumberPlate, String Name, int Model, String Make, double PetrolInLitres, double DrivenInKms, String Cnic, int EngineCC)
        {
            if (VerifyCar(NumberPlate, Cnic) == true)
            {
                String queryString = "Insert Into Cars (NumberPlate,Name , Model ,Make ,PetrolInLitres,DrivenInKms,Rating ,Cnic,EngineCC)" +
"Values('" + NumberPlate + "','" + Name + "','" + Model + ",'" + Make + "','" + PetrolInLitres + "','" + DrivenInKms
+ "','" + null + "','" + Cnic + "','" + EngineCC + "')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    if (queryString != null)
                    {
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public static bool RemoveDriver(String Name, String Email, String Address, String Password, String NumberPlate, String PhoneNo, String Cnic, int Rating, double Paymentbalance, double FineAmount, int YearsOfExperience)
        {
            if (DriverRegistrationVerification(PhoneNo) == true)
            {
                String queryString = "Insert Into Drivers (PhoneNo,Name,Email,Address,NumberPlate,Cnic,Rating,Paymentbalance,FineAmount,YearsOfExperience,Password)" +
                "Values('" + PhoneNo + "','" + Name + "','" + Email + ",'" + Address + "','" + null + "','" + Cnic
                + "','" + Rating + "','" + null + "','" + null + "','" + YearsOfExperience + "','" + Password + "')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    if (queryString != null)
                    {
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public static bool RemovePeople(String Cnic, String Name, String Password, String PhoneNo, String Email)
        {
            if (UserRegistrationVerification(Cnic) == true)
            {
                //  RETURNS TRUE IF REGISTRATION SUCCESSFUL
                String queryString = "Insert Into People (Cnic,Name,Password,PhoneNo,PaymentBalance,Email)" +
                "Values('" + Cnic + "','" + Name + "','" + Password + ",'" + PhoneNo + "','" + null + "','" + Email + "')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(queryString, con);
                try
                {
                    if (queryString != null)
                    {
                        return true;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error" + ex.Message.ToString());
                    return false;
                }
                finally
                {
                    con.Close();
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        //PostAd

        //RentTheCar
        //    -getcars

        //RentTheDriver
        //    -getdrivers

        //ReturnTheCar
        //    -
        

    }
}