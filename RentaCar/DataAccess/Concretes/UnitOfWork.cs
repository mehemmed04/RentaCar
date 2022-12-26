using RentaCar.DataAccess.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.DataAccess.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICarRepository CarRepository =>  new CarRepository();

        public IUserRepository UserRepository =>  new UserRepository();

        public IAdminRepository AdminRepository =>  new AdminRepository();
    }
}
