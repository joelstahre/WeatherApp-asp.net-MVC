using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Models.Abstract {
    public interface IWeatherRepository : IDisposable {

        string[] Get(Position position);
        void Add(Position positon, String data);
    }
}
