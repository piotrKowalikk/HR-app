using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HR.DataAccess.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("CompanyId")]
        public ICollection<JobOffer> JobOffers { get; set; }
    }
}
