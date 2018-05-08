using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.AReviews;

namespace BusinessLayer.RestaurantComp
{
    [Serializable]
    public class Restaurant 
    {
        public int RestaurantID { get; set; }
        public string name { get; set; }
        public string cuisine { get; set; }
        public string restAddress { get; set; }
        public string phoneNumber { get; set; }
        public List<AReview> reviews;

        public Restaurant()
        {
            this.name = null;
            this.cuisine = null;
            this.reviews = new List<AReview>();
        }

        public Restaurant(int Id, string name, string cuisine, string restAddress, string phoneNumber)
        {
            RestaurantID = Id;
            this.name = name;
            this.cuisine = cuisine;
            reviews = new List<AReview>();
            this.restAddress = restAddress;
            this.phoneNumber = phoneNumber;
        }

        public Restaurant(string name)
        {
            this.name = name;
            this.cuisine = null;
            this.reviews = new List<AReview>();
        }

        public Restaurant(string name, string cuisine)
        {
            this.name = name;
            this.cuisine = cuisine;
            this.reviews = new List<AReview>();
        }

        public Restaurant(string name, string cuisine, AReview review)
        {
            this.name = name;
            this.cuisine = cuisine;
            reviews = new List<AReview>();
            reviews.Add(review);
        }

        public void AddReview(AReview review)
        {
            reviews.Add(review);
        }

        public double CalculateAverageRating()
        {
            double sum = 0;
            int divisor = 0;
            foreach (AReview x in reviews)
            {
                sum += x.rating;
                divisor++;
            }
            return sum / divisor;
        }

        public void SortReviewWorstToBest()
        {
            if (reviews.Any())
            {
                WorstToBestRatingSorter WTBSorter = new WorstToBestRatingSorter();
                reviews.Sort(WTBSorter);
            }
            else
            {
                Console.WriteLine("There are no reviews for this Restaurant.");
            }
        }

        public void SortReviewBestToWorst()
        {
            if(reviews.Any())
            {
                BestToWorstSorter BTWSorter = new BestToWorstSorter();
                reviews.Sort(BTWSorter);
            }
            else
            {
                Console.WriteLine("There are no reviews for this Restaurant.");
            }
        }

        public IEnumerable<AReview> GetReviews()
        {
            return reviews;
        }

        //public void PrintReviews()
        //{
        //    Console.WriteLine("Restaurant Name: {0}  Cuisine: {1}", name, cuisine);
        //    if (reviews.Any())
        //    {
        //        //Console.WriteLine("Restaurant Name: ", name, "Cuisine: ", cuisine);
        //        Console.WriteLine("The average review rating: {0}", this.CalculateAverageRating());
        //        foreach (AReview x in reviews)
        //        {
        //            if (!x.rating.Equals(0))
        //            {
        //                Console.WriteLine("Rating: {0}", x.rating);
        //                if (String.IsNullOrEmpty(x.written))
        //                {
        //                    Console.WriteLine("There is no written Review for this Rating");
        //                }
        //                else
        //                {
        //                    Console.WriteLine(x.written);
        //                }
        //                Console.WriteLine("*****************************");
        //            }
        //            else
        //            {
        //                Console.WriteLine("This Review was never completed");

        //            }
        //        }
        //   }
        //}
    }

    public class WorstToBestRatingSorter : IComparer<AReview>
    {
        public int Compare(AReview x, AReview y)
        {
            if(x.rating.Equals(0))
            {
                if(y.rating.Equals(0))
                {
                    return 0;
                }
                else { return -1;}
            }
            else
            {
                if(y.rating.Equals(0))
                {
                    return 1;
                }
                else
                {
                    if(x.rating > y.rating)
                    {
                        return 1;
                    }
                    else if(x.rating < y.rating)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }

    public class BestToWorstSorter : IComparer<AReview>
    {
        public int Compare(AReview x, AReview y)
        {
            if (x.rating.Equals(0))
            {
                if (y.rating.Equals(0))
                {
                    return 0;
                }
                else { return -1; }
            }
            else
            {
                if (y.rating.Equals(0))
                {
                    return 1;
                }
                else
                {
                    if (x.rating < y.rating)
                    {
                        return 1;
                    }
                    else if (x.rating > y.rating)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }
    }

}
