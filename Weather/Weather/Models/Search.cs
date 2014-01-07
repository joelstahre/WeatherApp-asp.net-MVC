using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Weather.Models {
    public class Search {

        [Required(ErrorMessage = "The Field can´t be empty!")]
        public string CityName { get; set; }

    }
}