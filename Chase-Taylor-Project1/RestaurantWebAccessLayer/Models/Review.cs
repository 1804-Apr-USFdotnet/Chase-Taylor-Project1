using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer.AReviews;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebAccessLayer.Models
{
    public class Review : BusinessLayer.AReviews.AReview
    {
        [Range(0, 5.0)]
        public override double rating {get; set;}

        public override string written { get; set; }

        [Required]
        public override int RestaurantID { get; set; }

        public Review()
        {

        }
        public Review(int Id)
        {
            RestaurantID = Id;
        }
        public Review(double rating, string written, int id)
        {
            this.rating = rating;
            this.written = written;
            this.RestaurantID = id;
        }


    }
}