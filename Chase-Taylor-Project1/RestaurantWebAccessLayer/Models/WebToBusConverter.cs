using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer.Reviews;

namespace RestaurantWebAccessLayer.Models
{
    public class WebToBusConverter
    {
        public static BusinessLayer.Reviews.Review RevWebToLibConversion(Review rev)
        {
            return new BusinessLayer.Reviews.Review(rev.rating, rev.written, rev.RestaurantID);
        }
    }
}