using OratorjuMSSPService.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;

namespace OratorjuMSSPService
{
    public class UtilsThought
    {
        public static String conn = System.Configuration.ConfigurationManager.ConnectionStrings["OratorjuMSSPDB"].ConnectionString;

        public static bool addThought(
            DateTime t_date,
            String t_friendlyDate,
            String t_content,
            String t_image)
        {
            bool isSuccessful = false;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("INSERT INTO dbo.thought(t_date, t_friendlyDate, t_content,t_image) VALUES (@t_date,@t_friendlyDate,@t_content,@t_image)"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@t_date", String.Format("{0:yyyyMMdd}", t_date));
                        command.Parameters.AddWithValue("@t_friendlyDate", t_friendlyDate);
                        command.Parameters.AddWithValue("@t_content", t_content);
                        command.Parameters.AddWithValue("@t_image", t_image);

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

        public static bool deleteThought(String t_date)
        {
            bool isSuccessful = false;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("DELETE t FROM dbo.Thought t WHERE t.t_date = @t_date"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@t_date", String.Format("{0:yyyyMMdd}", t_date));

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

        public static bool updateThought(String t_date, string t_friendlyDate, string t_content, Stream t_image)
        {
            bool isSuccessful = true;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                //IMAGE NOT BEING UPDATED FOR NOW DUE TO TIME CONSTRAINTS
                //so is content to preserve the multiple lines
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("UPDATE t SET t.t_friendlyDate = @t_friendlyDate FROM dbo.Thought t WHERE t_date = @t_date"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@t_date", String.Format("{0:yyyyMMdd}", t_date));
                        command.Parameters.AddWithValue("@t_friendlyDate", t_friendlyDate);
                        command.Parameters.AddWithValue("@t_content", t_content);
                        //command.Parameters.AddWithValue("@t_image", t_image);
                        
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

        public static List<Thought> getAllThoughts()
        {
            List<Thought> Thoughts = new List<Thought>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using(var command = new SqlCommand("SELECT t_date, t_friendlyDate, t_content, t_image FROM dbo.Thought ORDER BY t_date DESC"))
                    {
                        command.Connection = connection;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //string src_date = reader.GetDateTime(0).ToShortDateString();
                            string src_date = reader.GetInt64(0).ToString();
                            string src_friendlyDate = reader.GetString(1);
                            string src_content = reader.GetString(2);
                            string src_image = reader.GetString(3);

                            Thoughts.Add(new Thought() { t_date = src_date, t_friendlyDate = src_friendlyDate,
                                t_content = src_content,
                                t_image = src_image});
                        }
                    }
                }
            }
            catch(Exception e) { }

            return Thoughts;
        }

        public static Thought getThoughtById(int id)
        {
            Thought t = null;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    using (var command = new SqlCommand("SELECT t_date, t_friendlyDate, t_content, t_image FROM dbo.Thought WHERE t_date = @id "))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //string src_date = reader.GetDateTime(0).ToShortDateString();
                            string src_date = reader.GetInt64(0).ToString();
                            string src_friendlyDate = reader.GetString(1);
                            string src_content = reader.GetString(2);
                            string src_image = reader.GetString(3);

                            t = (new Thought()
                            {
                                t_date = src_date,
                                t_friendlyDate = src_friendlyDate,
                                t_content = src_content,
                                t_image = src_image
                            });
                        }
                    }
                }
            }
            catch (Exception e) { }

            return t;
        }

        public static List<Thought> getThoughtsFrom(string t_date)
        {
            List<Thought> Thoughts = new List<Thought>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            try
            {
                using (var connection = new SqlConnection(conn))
                {
                    //not getting image for now - too much of a load
                    connection.Open();
                    using (var command = new SqlCommand("SELECT t_date, t_friendlyDate, t_content, t_image FROM dbo.Thought WHERE t_date >=@t_date ORDER BY t_date ASC"))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@t_date", t_date);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            //string src_date = reader.GetDateTime(0).ToShortDateString();
                            string src_date = reader.GetInt64(0).ToString();
                            string src_friendlyDate = reader.GetString(1);
                            string src_content = reader.GetString(2);
                            string src_image = reader.GetString(3);
                            //Stream src_image = reader.GetStream(3);

                            Thoughts.Add(new Thought() { t_date = src_date, t_friendlyDate = src_friendlyDate,
                                t_content = src_content,
                                t_image = src_image// src_image
                            });
                        }
                    }
                }
            }
            catch (Exception e) { }

            return Thoughts;
        }

    }
}