using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace Weather.Models {
    public class ParseWeather {


        public IEnumerable<Weather> getData(string rawJson) {

            DateTime today = DateTime.Now;
       
            var json = JObject.Parse(rawJson);
            var results = json["list"];

            var weathers = new List<Weather>();

            int counter = 1;

            foreach (var item in results) {

                var time = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds((double)item["dt"]).ToLocalTime();
                var temp = (double)item["main"]["temp"];
                var symbol = (string)item["weather"][0]["icon"];


                if (time.Day == today.Day && counter <= 5) {

                    if (time.Hour == 13 || time.Hour == 16 || time.Hour == 19) {

                        weathers.Add(new Weather(time, temp, symbol));
                        today = today.AddDays(1);
                        counter++;
                    }
                    else if (today.Hour > 22) {
                        today = today.AddDays(1);
                        counter++;
                    }
                }
            }

            return weathers;
        


        }


    }
}