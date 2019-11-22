using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.DataAccess.Models

{
    public class JobOffer : Entity
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public int? SalaryFrom { get; set; }
        public int? SalaryTo { get; set; }
        public bool IsActive { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateExpiration { get; set; }
        public string UserPosting { get; set; }
        public string UserApply { get; set; }
        public virtual Company Company { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; } 
    }
}
