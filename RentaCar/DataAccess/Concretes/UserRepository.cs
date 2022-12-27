using Dapper;
using RentaCar.DataAccess.Abstractions;
using RentaCar.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.DataAccess.Concretes
{
    public class UserRepository : IUserRepository
    {
        public void Add(User data)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Users WHERE Id=@id";
                var user = conn.QueryFirstOrDefault<User>(sql, new {id=id});
                return user;
            }
        }

        private string ConnectionString { get; set; }
        public UserRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }
        public IEnumerable<User> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Users";
                var users = conn.Query<User>(sql);
                return users;
            }

        }

        public void Update(User data)
        {
            throw new NotImplementedException();
        }
    }
}
