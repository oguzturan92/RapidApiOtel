using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApi_Odev.Models
{
    public class SearchModel
    {
        public string City { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int AdultCount { get; set; }
        public int RoomCount { get; set; }
    }
}