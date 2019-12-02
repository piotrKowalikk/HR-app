using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.DataAccess.Models

{
    public class JobOffer : Entity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }

        [Required]
        public string Position { get; set; }

        public string Description { get; set; }

        [Required]
        [DisplayName("Salary from")]
        public int? SalaryFrom { get; set; }

        [Required]
        [DisplayName("Salary to")]
        public int? SalaryTo { get; set; }

        [Required]
        [DisplayName("Is active")]
        public bool IsActive { get; set; }

        [Required]
        [DisplayName("Posted date")]
        public DateTime DatePosted { get; set; }

        [DisplayName("Expiration date")]
        public DateTime DateExpiration { get; set; }

        [Required]
        [DisplayName("Posted by")]
        public string UserPosting { get; set; }

        public virtual Company Company { get; set; }
        public ICollection<JobApplication> JobApplications { get; set; } 
    }
}
