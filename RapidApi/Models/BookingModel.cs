using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApi_Odev.Models
{
    public class BookingModel
    {
        public Data data { get; set; }
        public class Data
        {
            public Hotel[] hotels { get; set; }
        }
        public class Hotel
        {
            public int hotel_id { get; set; } // otelId
            public string accessibilityLabel { get; set; } // subdes
            public Property1 property { get; set; }
        }
        public class Property1
        {
            public string currency { get; set; } // fiyat birimi
            public string wishlistName { get; set; } // il adı
            public string[] photoUrls { get; set; } // fotourl
            public int reviewCount { get; set; } // fiyat
            public string name { get; set; } // adı
			public string checkinDate { get; set; }
			public string checkoutDate { get; set; }
        }
    }
}