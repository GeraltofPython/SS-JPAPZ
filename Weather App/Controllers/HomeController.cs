using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Weather_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetWeather(string wid)
        {

            string json = SendRequest("https://www.metaweather.com/api/location/" + wid);
            JObject data = JObject.Parse(json);

            WeatherList current = new WeatherList();

            current.cityName = (string)data["title"];
            current.locationType = (string)data["location_type"];

            current.list = new List<WeatherInfo>();

            for(int i = 0; i < data["consolidated_weather"].Count(); i++)
            {
                WeatherInfo temp = new WeatherInfo();

                temp.weatherStateName = (string)data["consolidated_weather"][i]["weather_state_name"];
                temp.minTemp = (string)data["consolidated_weather"][i]["min_temp"];
                temp.maxTemp = (string)data["consolidated_weather"][i]["max_temp"];
                temp.date = (string)data["consolidated_weather"][i]["applicable_date"];

                current.list.Add(temp);
            }

            return Json(current, JsonRequestBehavior.AllowGet);
        }
        private string SendRequest(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            /*            request.Headers.Add("Authorization", "token " + credentials);
                        request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
                        request.Accept = "application/json";*/

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }
    }

    public class WeatherInfo
    {
        public string weatherStateName;
        public string minTemp;
        public string maxTemp;
        public string date;
    }

    public class WeatherList
    {
        public string cityName;
        public string locationType;
        public List<WeatherInfo> list;
    }
}


/* 
 * We are going to grab wind_direction_compass, the_temp, humidity, visibility, sun_rise, sun_set, timezone
 * add another city
 */
