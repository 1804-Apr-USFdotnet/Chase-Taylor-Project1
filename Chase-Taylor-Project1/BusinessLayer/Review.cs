using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.AReviews;

namespace BusinessLayer.Reviews
{
    [Serializable]
    public class Review : AReview
    {   
        public override double rating { get; set; }
        public override string written { get; set; }
        public override int RestaurantID { get; set; }
        public Review()
        {
            rating = 0;
            written = null;
        }

        public Review(double rating)
        {
            this.rating = rating;
            written = null;
        }

        public Review(double rating, string written, int restaurantID)
        {
            this.rating = rating;
            this.written = written;
            this.RestaurantID = restaurantID;
        }

    }
}
