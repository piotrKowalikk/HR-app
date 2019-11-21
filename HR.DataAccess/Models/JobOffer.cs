﻿using System;
using System.Collections.Generic;
namespace HR.DataAccess.Models

{
    public class JobOffer : Entity
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }
        public int IsActive { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateExpiration { get; set; }
        public int UserPosting { get; set; }
        public int? UserApply { get; set; }

        public virtual OfferStatus IsActiveNavigation { get; set; }
    }
}