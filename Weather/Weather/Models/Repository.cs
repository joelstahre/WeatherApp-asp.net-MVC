using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Weather.Models;
using Weather.Models.DataModels;

namespace  Weather.Models {

    public class Repository : Models.Abstract.IWeatherRepository {

        private WeatherEntities _entities = new WeatherEntities();

        public string[] Get(Position position) {
            return _entities.usp_GetCache(position.Latitude, position.Longitude).ToArray();


        }

       public void Add(Position positon, String data) {
           _entities.usp_AddCache(positon.Latitude, positon.Longitude, data);
        }


        #region IDisposable

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (!this._disposed) {
                if (disposing) {
                    _entities.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}