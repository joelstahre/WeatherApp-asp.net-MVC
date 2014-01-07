using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models {
    public class Weather {
        public Weather() {
            // Empty!
        }

        public Weather(DateTime time, double temperature, string symbolId) {
            Time = time;
            Temperature = temperature;
            SymbolId = symbolId;

        }

        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public string SymbolId { get; set; }
    }

}