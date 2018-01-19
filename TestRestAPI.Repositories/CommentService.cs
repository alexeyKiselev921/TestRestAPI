using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRestAPI.Models;
using TestRestAPI.Repositories.Interfaces;

namespace TestRestAPI.Repositories
{
    public class CommentService : ICommentsService
    {
        public void AddComment(Comment comment)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CreateComment", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar).Value = comment.Text;
                        cmd.Parameters.Add("@postId", System.Data.SqlDbType.BigInt).Value = comment.PostId;
                        cmd.Parameters.Add("@authorId", System.Data.SqlDbType.BigInt).Value = comment.AuthorId;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void DeleteComment(int commentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteComment", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = commentId;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void EditComment(Comment comment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("EditComment", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@text", System.Data.SqlDbType.NVarChar).Value = comment.Text;
                        cmd.Parameters.Add("@id", System.Data.SqlDbType.BigInt).Value = comment.Id;
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Comment[] GetAll(long postId)
        {
            List<Comment> result = new List<Comment>();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetComments", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@postId", System.Data.SqlDbType.BigInt).Value = postId;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while(reader.Read())
                        {
                            result.Add(new Comment()
                            {
                                Id = reader.GetInt32(0),
                                AuthorId = reader.GetInt32(1),
                                Text = reader.GetString(2),
                                PostId = reader.GetInt32(4),
                                Date = reader.GetDateTime(3)
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

        public Comment GetComment(int id)
        {
            try
            {
                Comment comment = new Comment();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("GetComments", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            
                        }
                        return comment;
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
