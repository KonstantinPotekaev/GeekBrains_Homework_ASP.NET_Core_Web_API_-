using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;

namespace WeatherForeCast.Models
{
    public class WeatherForeCastHolder
    {
        private List<WeatherForeCast> _forecasts;

        #region Конструкторы
        
        public WeatherForeCastHolder()
        {
            _forecasts = new List<WeatherForeCast>();
        }

        #endregion

        /// <summary>
        /// Добавление показаний температуры
        /// </summary>
        /// <param name="date">Дата фиксации</param>
        /// <param name="temperatureC">Тепература в градусах Цельсия</param>
        public void Add(DateTime date, double temperatureC)
        {
            _forecasts.Add(new WeatherForeCast() { Date = date, TemperatureC = temperatureC });
        }

        /// <summary>
        /// Получение показаний температур в указанный промежутак времени
        /// </summary>
        /// <param name="dateFrom">Начальная дата</param>
        /// <param name="dateTo">Конечная дата</param>
        /// <returns></returns>
        public List<WeatherForeCast> Get(DateTime dateFrom, DateTime dateTo)
        {
            return _forecasts.FindAll(item => item.Date >= dateFrom && item.Date <= dateTo);
        }

        /// <summary>
        /// Обновление показаний температур в указанную дату
        /// </summary>
        /// <param name="date">Дата</param>
        /// <param name="temperatureC">Обновленная температура</param>
        /// <returns>True or False(удалили или нет)</returns>
        public bool Update(DateTime date, double temperatureC)
        {
            foreach (var item in _forecasts)
            {
                if (item.Date == date)
                {
                    item.TemperatureC = temperatureC;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Удаление показаний температуры в указанное время
        /// </summary>
        /// <param name="date">Время</param>
        /// <returns>Удалили или нет</returns>
        public bool Delete(DateTime date)
        {
            int cnt = 0;
            foreach (var item in _forecasts)
            {
                if (date == item.Date)
                {
                    _forecasts.RemoveAt(cnt);
                    return true;
                }
                cnt++;
            }
            return true;
        }
        
    }
}




