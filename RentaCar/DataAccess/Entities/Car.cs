using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaCar.DataAccess.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public string ImagePath { get; set; }
        public decimal PricePerDay { get; set; }
        public int SeatCount { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
