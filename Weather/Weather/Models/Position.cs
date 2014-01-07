using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models {
    public class Position {
        public Position() {
            // Empty!
        }

        public Position(string cityName, string address, double latitude, double longitude) {
            CityName = cityName;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string CityName { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}