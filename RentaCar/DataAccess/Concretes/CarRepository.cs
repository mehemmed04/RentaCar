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
    public class CarRepository : ICarRepository
    {
        private string ConnectionString { get; set; }
        public CarRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
        }
        public void Add(Car data)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Car Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            using(var conn = new SqlConnection(ConnectionString))
            {
                var sql = @"SELECT * FROM Cars";
                var cars = conn.Query<Car>(sql);
                return cars;
            }
        }

        public void Update(Car data)
        {
            throw new NotImplementedException();
        }
    }
}
