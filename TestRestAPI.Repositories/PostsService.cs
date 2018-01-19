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
    public class PostsService : IPostsService
    {
        public void AddPost(Post post)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CreatePost", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@text", SqlDbType.NVarChar).Value = post.Text;
                        cmd.Parameters.Add("@authorId", SqlDbType.BigInt).Value = post.AuthorId;
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

        public void DeletePost(long postId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeletePost", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = postId;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void EditPost(Post post)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("EditPost", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = post.Id;
                        cmd.Parameters.Add("@text", SqlDbType.NVarChar).Value = post.Text;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        public Post[] GetAll()
        {
            List<Post> result = new List<Post>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetPosts", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Post()
                            {
                                Id = reader.GetInt64(0),
                                Text = reader.GetString(1),
                                Date = reader.GetDateTime(2)
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

        public Post GetPost(long id)
        {
            try
            {
                Post post = new Post();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetComments", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                        }
                        return post;
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
