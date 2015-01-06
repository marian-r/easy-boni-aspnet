using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using EasyBoni.Models.DAL;
using EasyBoni.Models.REST;

namespace EasyBoni.Models
{
    /// <summary>
    /// Singleton
    /// </summary>
    public class RestaurantsManager
    {
        private List<Restaurant> restaurants = new List<Restaurant>();
        private static RestaurantsManager instance = new RestaurantsManager();

        public List<Restaurant> Restaurants
        {
            get
            {
                if (restaurants.Count == 0)
                {
                    var restClient = new RestaurantsClient();
                    restaurants = restClient.GetRestaurants();
                }

                RatingsManager ratingsManager = new RatingsManager();
                var ratings = ratingsManager.FindForAllRestaurants();
                foreach (var restaurant in restaurants)
                {
                    double rating;
                    if (ratings.TryGetValue(restaurant.ID, out rating))
                    {
                        restaurant.Rating = Math.Round(rating);
                    }
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