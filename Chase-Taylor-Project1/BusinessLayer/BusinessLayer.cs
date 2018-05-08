using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryConversion;
using RestaurantDataAccessLayer;
using BusinessLayer.Reviews;

namespace BusinessLayer
{
    public class BusinessLayer
    {
        public static IEnumerable<RestaurantComp.Restaurant> GetTop3()
        {
            Crud<RestaurantDataAccessLayer.Restaurant> crud = new Crud<Restaurant>();
            List<RestaurantComp.Restaurant> returnList = new List<RestaurantComp.Restaurant>();
            foreach (RestaurantDataAccessLayer.Restaurant x in crud.ToList())
            {
                returnList.Add(LibraryConverter.RestDataToLibConversion(x));
            }
            returnList.Sort(new BestToWorstSorter());
            if (returnList.Count >= 3)
            {
                return returnList.GetRange(0, 3);
            }
            else
            {
                return returnList;
            }
        }

        public static IEnumerable<RestaurantComp.Restaurant> GetDataRestaurants()
        {
            Crud<RestaurantDataAccessLayer.Restaurant> crud = new Crud<Restaurant>();
            List<RestaurantComp.Restaurant> returnList = new List<RestaurantComp.Restaurant>();
            foreach (RestaurantDataAccessLayer.Restaurant x in crud.ToList())
            {
                returnList.Add(LibraryConverter.RestDataToLibConversion(x));
            }
            return returnList;
        }

        public static IEnumerable<RestaurantComp.Restaurant> SearchRestaurants(string p)
        {
            List<RestaurantComp.Restaurant> unsearched = BusinessLayer.GetDataRestaurants().ToList();
            List<RestaurantComp.Restaurant> searched = new List<RestaurantComp.Restaurant>();
            foreach (RestaurantComp.Restaurant x in unsearched)
            {
                if (!String.IsNullOrEmpty(p))
                {
                    if (x.name.ToLower().Contains(p.ToLower()))
                    {
                        searched.Add(x);
                    }
                }
            }
            return searched;
        }

        public static void AddReview(Reviews.Review rev)
        {
            Crud<RestaurantDataAccessLayer.Review> crud = new Crud<RestaurantDataAccessLayer.Review>();
            crud.Add(LibraryConverter.RevLibToDataConverion(rev));
        }
    }
}
