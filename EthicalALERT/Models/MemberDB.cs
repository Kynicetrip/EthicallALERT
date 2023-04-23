using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EthicalALERT.Models
{
    
    
    public class MemberDB
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=EthicalAlertDB;Integrated Security=True";

        public List<Member> GetAllMembers()
        {
            List<Member> members = new List<Member>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Members";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Member member = new Member()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"]
                        };
                        members.Add(member);
                    }
                }
            }

            return members;
        }

        public Member GetMemberById(int id)
        {
            Member member = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Members WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        member = new Member()
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"]
                        };
                    }
                }
            }

            return member;
        }

        public void AddMember(Member member)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Members (Name, Email, Password) VALUES (@Name, @Email, @Password)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", member.Name);
                    command.Parameters.AddWithValue("@Email", member.Email);
                    command.Parameters.AddWithValue("@Password", member.Password);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateMember(Member member)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Members SET Name = @Name, Email = @Email, Password = @Password WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", member.Name);
                    command.Parameters.AddWithValue("@Email", member.Email);
                    command.Parameters.AddWithValue("@Password", member.Password);
                    command.Parameters.AddWithValue("@Id", member.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteMember(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Members WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

}