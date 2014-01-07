using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Weather.Models.WebServices {
    public class OpenWeather {

        public string getData(Position position) {

            var lat = position.Latitude.ToString("0.00000000000000", CultureInfo.InvariantCulture);
            var lng = position.Longitude.ToString("0.00000000000000", CultureInfo.InvariantCulture);

            var requestUriString = String.Format("http://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&APPID=09d8c81c783e36aaeaec3ddbb68001f8", lat, lng);

            var rawJson = String.Empty;
            var request = (HttpWebRequest)WebRequest.Create(requestUriString);
            request.Method = "GET";
            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream())) {
                rawJson = reader.ReadToEnd();
            }

            return rawJson;

        }
    }
}