using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;

namespace EasyBoni.Models
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class RestaurantsManager
    {
        const string REQUEST_URL = "http://bonar.si/api/restaurants";

        private List<Restaurant> restaurants = new List<Restaurant>();
        private static RestaurantsManager instance = new RestaurantsManager();

        public List<Restaurant> Restaurants
        {
            get
            {
                if (restaurants.Count == 0)
                {
                    HttpClient httpClient = new HttpClient();
                    string json = httpClient.GetStringAsync(REQUEST_URL).Result;

                    restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(json);
                }

                return restaurants;
            }
        }

        public static RestaurantsManager Instance
        {
            get { return instance; }
        }


        private RestaurantsManager()
        {
        }
    }
}