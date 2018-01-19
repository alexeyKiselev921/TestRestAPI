using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestAPI.Models;
using TestRestAPI.Repositories.Interfaces;

namespace TestRestAPI.Repositories
{
    public class AuthorsService : IAuthorsService
    {
        public void AddAuthor(Author author)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CreateAuthor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = author.UserName;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DeleteAuthor(long authorId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteAuthor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = authorId;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void EditAuthor(Author author)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("EditAuthor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = author.Id;
                        cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = author.UserName;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Author[] GetAll()
        {
            List<Author> result = new List<Author>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetAuthors", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Author()
                            {
                                Id = reader.GetInt64(0),
                                UserName = reader.GetString(1)
                            });
                        }
                        return result.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result.ToArray();
        }

        public Author GetAuthor(long id)
        {
            try
            {
                Author author = new Author();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetComments", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            author.Id = reader.GetInt64(0);
                            author.UserName = reader.GetString(1);
                        }
                        return author;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
    }
}
