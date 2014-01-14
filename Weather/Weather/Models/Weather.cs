using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models {
    public class Weather {


        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public string SymbolId { get; set; }
        public string Desc { get; set; }

        public Weather() {
            // Empty!
        }

        public Weather(DateTime time, double temperature, string symbolId, string desc) {
            Time = time;
            Temperature = temperature;
            SymbolId = symbolId;
            Desc = desc;
        }

        
    }

}