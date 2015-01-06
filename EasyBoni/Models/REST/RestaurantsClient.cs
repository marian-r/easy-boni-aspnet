using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace EasyBoni.Models.REST
{
    public class RestaurantsClient
    {
        const string REQUEST_URL = "http://bonar.si/api/restaurants";

        public List<Restaurant> GetRestaurants()
        {
            var httpClient = new HttpClient();
            string json = httpClient.GetStringAsync(REQUEST_URL).Result;

            return JsonConvert.DeserializeObject<List<Restaurant>>(json);
        }
    }
}