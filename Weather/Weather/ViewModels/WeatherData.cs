using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Models;
using Weather.Models.WebServices;


namespace Weather.ViewModels {
    public class WeatherData {

        private IEnumerable<Models.Weather> _data;
        private string _address;
        private DateTime today = DateTime.Now;

        public WeatherData(IEnumerable<Models.Weather> data, Position position) {
            _data = data;
            _address = position.Address;
        }

        public IEnumerable<Models.Weather> getList() {
            return _data.ToList();
        }


       public string getLocation() {
            return _address;
        }

        public string getDay(System.DateTime day) {

            if (today.Day == day.Day) {
                return "Today";
            } else if (today.Day +1 == day.Day) {
                return "Tomorrow";
            }
            else {
                return day.DayOfWeek.ToString();
            }
        }

        public string getTemp(double temp) {

            return temp.ToString("0.0");
        }

    }
}