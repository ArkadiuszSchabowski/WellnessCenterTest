using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaSalon.Database.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Price { get; set; }
        public DateTime Date { get; set; }
        public bool isPaid { get; set; }
    }
}
