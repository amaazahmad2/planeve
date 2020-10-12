using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace db_final.Models
{
    public class Review
    {
        public string serviceProviderID;
        public string serviceCategory;
        public string reviewCustomerID;
        public string reviewComments;
        public string reviewRating;

        //    ProviderID varchar(50) NOT NULL,
        //  ServiceCategory varchar(40) NOT NULL,
        //  ReviewCustomerID varchar(50) NOT NULL,
        //  ReviewComments  varchar(500),
        //ReviewRating float check(ReviewRating between 0 and 5),
        //}
    }
}