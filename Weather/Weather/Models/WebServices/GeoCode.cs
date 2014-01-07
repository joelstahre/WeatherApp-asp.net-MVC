using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace Weather.Models.WebServices {
    public class GeoCode {

        public IEnumerable<Position> getPosition(string city) {

            var rawJson = String.Empty;
            var requestUriString = String.Format("http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false", city);
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Method = "GET";
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream())) {
                rawJson = reader.ReadToEnd();
            }

            var json = JObject.Parse(rawJson);
            var results = json["results"];
            var positions = new List<Position>();
            for (int i = 0; i < results.Count(); i++) {
                var address = (string)results[i]["formatted_address"];
                var lat = (double)results[i]["geometry"]["location"]["lat"];
                var lng = (double)results[i]["geometry"]["location"]["lng"];
                positions.Add(new Position(city, address, lat, lng));
            }

            return positions;

        }
    }
}