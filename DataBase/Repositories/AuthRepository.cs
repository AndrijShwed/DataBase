using MySqlConnector;
using System;

namespace DataBase.Repositories
{
    public class AuthRepository
    {
        public User Authenticate(string login, string password)
        {
            string hash = SecurityHelper.HashPassword(password);
            using (ConnectionClass conn = new ConnectionClass())
            {
                conn.openConnection();
                string query = "SELECT id, login, role FROM users WHERE login = @login AND password_hash = @pass";

                using (MySqlCommand cmd = new MySqlCommand(query, conn.getConnection()))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@pass", hash);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Login = reader["login"].ToString(),
                                Role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
