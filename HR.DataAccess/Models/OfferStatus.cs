using System;
using System.Collections.Generic;

namespace HR.DataAccess.Models
{
    public partial class OfferStatus
    {
        public OfferStatus()
        {
            AppOffers = new HashSet<JobOffer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<JobOffer> AppOffers { get; set; }
    }
}
