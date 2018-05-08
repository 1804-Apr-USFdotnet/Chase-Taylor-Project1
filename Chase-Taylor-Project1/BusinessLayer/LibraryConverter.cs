using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDataAccessLayer;
using BusinessLayer.RestaurantComp;
using BusinessLayer.Reviews;
using BusinessLayer.AReviews;

namespace LibraryConversion
{
    public class LibraryConverter
    {

        public LibraryConverter()
        {
        }

        //public List<BusinessLayer.RestaurantComp.Restaurant> RestDataToLibConversion()
        //{
        //    List<BusinessLayer.RestaurantComp.Restaurant> returnList = new List<BusinessLayer.RestaurantComp.Restaurant>();
        //    Crud<RestaurantDataAccessLayer.Restaurant> crud = new Crud<RestaurantDataAccessLayer.Restaurant>();
        //    Crud<RestaurantDataAccessLayer.Review> crud1 = new Crud<RestaurantDataAccessLayer.Review>();
        //    foreach (RestaurantDataAccessLayer.Restaurant x in crud.ToList())
        //    {
        //        returnList.Add(new BusinessLayer.RestaurantComp.Restaurant(x.RName, x.Cuisine, x.RestAddress, x.PhoneNumber));
        //        foreach (RestaurantDataAccessLayer.Review y in crud1.ToList())
        //        {
        //            if(y.RestaurantID == x.RestaurantID)
        //            {
        //                returnList[x.RestaurantID-1].AddReview(new BusinessLayer.Reviews.Review((double)y.Rating, y.written));
        //            }
        //        }
        //    }

        //    return returnList;
        //}
        public static BusinessLayer.RestaurantComp.Restaurant RestDataToLibConversion(RestaurantDataAccessLayer.Restaurant p)
        {
            Crud<RestaurantDataAccessLayer.Review> crud1 = new Crud<RestaurantDataAccessLayer.Review>();
            BusinessLayer.RestaurantComp.Restaurant r = new BusinessLayer.RestaurantComp.Restaurant(p.RestaurantID, p.RName, p.Cuisine, p.RestAddress, p.PhoneNumber);
            foreach (RestaurantDataAccessLayer.Review y in crud1.ToList())
            {
                if (y.RestaurantID == r.RestaurantID)
                {
                    r.AddReview(new BusinessLayer.Reviews.Review((double)y.Rating, y.written, y.RestaurantID));
                }
            }

            return r;
        }
        public static RestaurantDataAccessLayer.Restaurant RestLibToDataConversion(BusinessLayer.RestaurantComp.Restaurant p)
        {
            RestaurantDataAccessLayer.Restaurant r = new RestaurantDataAccessLayer.Restaurant();
            r.RName = p.name;
            r.Cuisine = p.cuisine;
            r.RestAddress = p.restAddress;
            r.PhoneNumber = p.phoneNumber;
            foreach (BusinessLayer.Reviews.Review y in p.reviews)
            {
                if (y.RestaurantID == r.RestaurantID)
                {
                    RestaurantDataAccessLayer.Review temp = new RestaurantDataAccessLayer.Review();
                    temp.Rating = y.rating;
                    temp.RestaurantID = y.RestaurantID;
                    temp.written = y.written;
                    r.Reviews.Add(temp);
                }
            }
            return r;
        }

        public static BusinessLayer.Reviews.Review RevDataToLibConversion(RestaurantDataAccessLayer.Review p)
        {
            return new BusinessLayer.Reviews.Review((double)p.Rating, p.written, p.RestaurantID);
        }

        public static RestaurantDataAccessLayer.Review RevLibToDataConverion(BusinessLayer.Reviews.Review p)
        {
            RestaurantDataAccessLayer.Review temp = new RestaurantDataAccessLayer.Review();
            temp.Rating = p.rating;
            temp.RestaurantID = p.RestaurantID;
            temp.written = p.written;
            temp.rownumber = new Crud<RestaurantDataAccessLayer.Review>().ToList().Count + 1;
            return temp;
        }
    }
}
