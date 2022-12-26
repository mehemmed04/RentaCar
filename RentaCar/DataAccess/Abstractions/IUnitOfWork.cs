﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.DataAccess.Abstractions
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IUserRepository UserRepository { get; }
        IAdminRepository AdminRepository { get; }
    }
}