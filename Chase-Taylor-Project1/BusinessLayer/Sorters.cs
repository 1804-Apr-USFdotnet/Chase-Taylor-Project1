using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BestToWorstSorter : IComparer<RestaurantComp.Restaurant>
    {
        public int Compare(RestaurantComp.Restaurant x, RestaurantComp.Restaurant y)
        {
            if (x.CalculateAverageRating().Equals(0))
            {
                if (y.CalculateAverageRating().Equals(0))
                {
                    return 0;
                }
                else { return -1; }
            }
            else
            {
                if (y.CalculateAverageRating().Equals(0))
                {
                    return 1;
                }
                else
                {
                    if (x.CalculateAverageRating() < y.CalculateAverageRating())
                    {
                        return 1;
                    }
                    else if (x.CalculateAverageRating() > y.CalculateAverageRating())
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

    public class WorstToBestRatingSorter : IComparer<RestaurantComp.Restaurant>
    {
        public int Compare(RestaurantComp.Restaurant x, RestaurantComp.Restaurant y)
        {
            if (x.CalculateAverageRating().Equals(0))
            {
                if (y.CalculateAverageRating().Equals(0))
                {
                    return 0;
                }
                else { return -1; }
            }
            else
            {
                if (y.CalculateAverageRating().Equals(0))
                {
                    return 1;
                }
                else
                {
                    if (x.CalculateAverageRating() > y.CalculateAverageRating())
                    {
                        return 1;
                    }
                    else if (x.CalculateAverageRating() < y.CalculateAverageRating())
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
