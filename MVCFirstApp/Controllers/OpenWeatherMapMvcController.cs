using MVCFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCFirstApp.Class;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
 
 

using System.Web.Script.Serialization;
using System.Net;


namespace MVCFirstApp.Controllers
{
    public class OpenWeatherMapMvcController : Controller
    {
        // GET: OpenWeatherMapMvc

        
        public ActionResult weatherForecast()
        { 
            var listItems = new List<Region>();

            listItems.Add(new Region(
                "7839805","Melbourne"));

            listItems.Add(new Region(
    "2193734", "Auckland"));
            listItems.Add(new Region(
    "1261481", "New Delhi"));
            listItems.Add(new Region(
    "1850144", "Tokyo"));
            listItems.Add(new Region(
    "1172451", "Lahore"));

            listItems.Add(new Region(
"2643743", "London"));

            listItems.Add(new Region(
                "1819729", "Hong Kong"));


            System.Diagnostics.Debug.WriteLine("gettttttt");
            Session["listItems"] = listItems;
            return View(listItems);
        }

        /*       [HttpPost]

               public async System.Threading.Tasks.Task<ActionResult> weatherForecast(FormCollection post)*/

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> weatherForecast(FormCollection post)
        {
            System.Diagnostics.Debug.WriteLine("possssssst");
            System.Diagnostics.Debug.WriteLine(post.Count);
            string apiKey = "32d2956038d6e14afabc59d7f016d6d5";
            List<ResponseWeather> responseList = new List<ResponseWeather>();

            foreach (var key in post.Keys)
            {
                System.Diagnostics.Debug.WriteLine(post[key.ToString()]);

                string id = post[key.ToString()];

                string url = "http://api.openweathermap.org/data/2.5/weather?id=" +
                    id + "&appid=" + apiKey + "&units=metric";

                

                using (var client = new HttpClient())
                {

                    HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine(url);
                        var jsonResponse = response.Content.ReadAsStringAsync().Result;
                        System.Diagnostics.Debug.WriteLine(jsonResponse);
                        var jsonObj = JsonConvert.DeserializeObject<ResponseWeather>(jsonResponse);


                        responseList.Add(jsonObj);

                        System.Diagnostics.Debug.WriteLine(jsonObj);

                    }
                     
                }

                 


                
                /*System.Diagnostics.Debug.WriteLine("possssssst");
                if (post.Count > 0)
                {

                    string apiKey = "32d2956038d6e14afabc59d7f016d6d5";
                    city = city.ToLower();
                   city =city.Replace(" ", "");

                    var id = Session[city];

                    System.Diagnostics.Debug.WriteLine(city);

                    string url = "http://api.openweathermap.org/data/2.5/weather?id=" +
                     id + "&appid=" + apiKey + "&units=metric";

                    using (var client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResponse = response.Content.ReadAsStringAsync().Result;

                            var jsonObj = JsonConvert.DeserializeObject<ResponseWeather>(jsonResponse);

                            System.Diagnostics.Debug.WriteLine(jsonResponse);
                            System.Diagnostics.Debug.WriteLine(jsonObj);
                            System.Diagnostics.Debug.WriteLine("possssssst");

                            ViewBag.Message = jsonObj;


                        }
                    }*/

            }
            ViewBag.Message = responseList;
            return View(Session["listItems"]);
        }
        
    }
}