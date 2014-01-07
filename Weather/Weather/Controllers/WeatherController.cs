using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Models;
using Weather.ViewModels;
using Weather.Models.WebServices;
using Weather.Models.Abstract;

namespace Weather.Controllers {
    public class WeatherController : Controller {
        
        private IWeatherRepository _repository;


        public WeatherController() {
            _repository = new Repository();
        }
        
        //
        // GET: /Weather/

        public ActionResult Index() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Search search) {

            if (!ModelState.IsValid) {
                ModelState.AddModelError("CustomError", "The Field can´t be empty!.");
            }

            try {

                var geoCode = new GeoCode();
                var position = geoCode.getPosition(search.CityName);
                return RedirectToAction("GetWeather", position.First());
            }
            catch (Exception) {

                ModelState.AddModelError("CustomError", "Positionen kan inte hittas.");
            }

            return View("Error");
        }

        public ActionResult GetWeather(Position position) {

            string data = String.Empty;

            try {
                string[] DBResult = _repository.Get(position);

                if (DBResult.Count() == 0) {
                    var weather = new OpenWeather();
                    data = weather.getData(position);
                    
                }
                else {
                    data = DBResult.First();
                }
            }
            catch (Exception) {

                ModelState.AddModelError("CustomError", "Fel vid hämtning av data.");
            }

            try {
                var parse = new ParseWeather();
                var parsedData = parse.getData(data);

                _repository.Add(position, data);

                var viewModel = new WeatherData(parsedData, position);

                return View("Weather", viewModel);
            }
            catch (Exception) {

                ModelState.AddModelError("CustomError", "Fel vid parsning av data.");
            }

            return View("Error");
        }

    }
}