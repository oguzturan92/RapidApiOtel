using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApi_Odev.Models
{
    public class OtelDetailModel
    {
        public Data data { get; set; }

		public class Data
		{
			public string hotel_name { get; set; } // otel adı
			public string url { get; set; } // otel url
			public string arrival_date { get; set; } // giriş
			public string departure_date { get; set; } // çıkış
			public string city { get; set; } // şehir
			public string country_trans { get; set; } // ülke
			public string currency_code { get; set; } // para birimi
            public string[] family_facilities { get; set; }
        }
		public string photoUrl { get; set; }
    }
}