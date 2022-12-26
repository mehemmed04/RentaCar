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
    public class AdminRepository : IAdminRepository
    {
        public void Add(Admin data)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Admin Get(int id)
        {
            throw new NotImplementedException();
        }

        private string ConnectionString { get; set; }
        public AdminRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }
        public IEnumerable<Admin> GetAll()
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Admins";
                var admins = conn.Query<Admin>(sql);
                return admins;
            }

        }

        public void Update(Admin data)
        {
            throw new NotImplementedException();
        }
    }
}
