using OratorjuMSSPService.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace OratorjuMSSPService
{
    public class Utils
    {
        public static String conn = System.Configuration.ConfigurationManager.ConnectionStrings["OratorjuMSSPDB"].ConnectionString;

        public static bool addReading(
            DateTime r_date,
            String r_qari1,
            String r_salm,
            String r_qari2,
            String r_vangelu,
            String r_friendlyDate)
        {
            bool isSuccessful = false;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("INSERT INTO dbo.reading(r_date,r_qari1,r_salm,r_qari2,r_vangelu,r_friendlyDate) VALUES (@r_date,@r_qari1,@r_salm,@r_qari2,@r_vangelu,@r_friendlyDate)"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@r_date", String.Format("{0:yyyyMMdd}", r_date));
                        command.Parameters.AddWithValue("@r_qari1", r_qari1);
                        command.Parameters.AddWithValue("@r_salm", r_salm);
                        command.Parameters.AddWithValue("@r_qari2", r_qari2);
                        command.Parameters.AddWithValue("@r_vangelu", r_vangelu);
                        command.Parameters.AddWithValue("@r_friendlyDate", r_friendlyDate);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            isSuccessful = true;
                        }
                    }

                }
            }
            catch(Exception e)
            { }

            return isSuccessful;
        }

        public static bool deleteReading(String r_date)
        {
            bool isSuccessful = false;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("DELETE r FROM dbo.reading r WHERE r.r_date = @r_date"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@r_date", String.Format("{0:yyyyMMdd}", r_date));

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            isSuccessful = true;
                        }
                    }
                }
            } 
            catch (Exception e) { }

            return isSuccessful;
       
        }

        public static bool updateReading(String r_date, string r_friendlyDate, string r_qari1, string r_salm, string r_qari2, string r_vangelu)
        {
            bool isSuccessful = true;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("UPDATE r SET r.r_friendlyDate = @r_friendlyDate, r.r_qari1 = @r_qari1, r.r_salm = @r_salm, r.r_qari2 = @r_qari2, r.r_vangelu = @r_vangelu FROM dbo.reading r WHERE r.r_date = @r_date"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@r_date", String.Format("{0:yyyyMMdd}", r_date));
                        command.Parameters.AddWithValue("@r_friendlyDate", r_friendlyDate);
                        command.Parameters.AddWithValue("@r_qari1", r_qari1);
                        command.Parameters.AddWithValue("@r_salm", r_salm);
                        command.Parameters.AddWithValue("@r_qari2", r_qari2);
                        command.Parameters.AddWithValue("@r_vangelu", r_vangelu);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 1)
                        {
                            isSuccessful = true;
                        }
                    }
                }
            }
            catch(Exception e) { }

            return isSuccessful;
        }

        public static List<Reading> getAllReadings()
        {
            List<Reading> readings = new List<Reading>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using(var command = new SqlCommand("SELECT r_date, r_friendlyDate, r_qari1, r_salm, r_qari2, r_vangelu FROM dbo.reading ORDER BY r_date DESC"))
                    {
                        command.Connection = connection;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //string src_date = reader.GetDateTime(0).ToShortDateString();
                            string src_date = reader.GetInt64(0).ToString();
                            string src_friendlyDate = reader.GetString(1);
                            string src_qari1 = reader.GetString(2);
                            string src_salm = reader.GetString(3);
                            string src_qari2 = reader.GetString(4);
                            string src_vangelu = reader.GetString(5);

                            readings.Add(new Reading() { r_date = src_date, r_friendlyDate = src_friendlyDate,
                                r_qari1 = src_qari1,
                                r_salm = src_salm,
                                r_qari2 = src_qari2,
                                r_vangelu = src_vangelu});
                        }
                    }
                }
            }
            catch(Exception e) { }

            return readings;
        }

        public static List<Reading> getReadingsFrom(string r_date)
        {
            List<Reading> readings = new List<Reading>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT r_date, r_friendlyDate, r_qari1, r_salm, r_qari2, r_vangelu FROM dbo.reading WHERE r_date >=@r_date ORDER BY r_date ASC"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@r_date", r_date);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //string src_date = reader.GetDateTime(0).ToShortDateString();
                            string src_date = reader.GetInt64(0).ToString();
                            string src_friendlyDate = reader.GetString(1);
                            string src_qari1 = reader.GetString(2);
                            string src_salm = reader.GetString(3);
                            string src_qari2 = reader.GetString(4);
                            string src_vangelu = reader.GetString(5);

                            readings.Add(new Reading() { r_date = src_date, r_friendlyDate = src_friendlyDate,
                                r_qari1 = src_qari1,
                                r_salm = src_salm,
                                r_qari2 = src_qari2,
                                r_vangelu = src_vangelu});
                        }
                    }
                }
            }
            catch (Exception e) { }

            return readings;
        }

    }
}