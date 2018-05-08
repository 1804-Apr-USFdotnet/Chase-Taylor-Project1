using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLayer.AReviews
{
    [Serializable]
    public abstract class AReview  
    {
        public abstract double rating { get; set; }
        public abstract string written { get; set; }
        public abstract int RestaurantID { get; set; }
    }
}
