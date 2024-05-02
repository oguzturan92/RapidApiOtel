using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapidApi_Odev.Models
{
    public class CityModel
    {
		public Data[] data { get; set; }

		public class Data
		{
			public string dest_id { get; set; }
		}
    }
}