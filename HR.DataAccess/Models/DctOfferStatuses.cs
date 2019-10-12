using System;
using System.Collections.Generic;

namespace HR.DataAccess.Models
{
    public partial class DctOfferStatuses
    {
        public DctOfferStatuses()
        {
            AppOffers = new HashSet<AppOffers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppOffers> AppOffers { get; set; }
    }
}
