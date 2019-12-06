using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.DataAccess.Models
{
    public partial class ApplicationUser : Entity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string NameIdentifier { get; set; }
        [NotMapped]
        public Roles GetRole
        {
            get
            {
                return (Models.Roles)this.RoleId;
            }
            set
            {
                RoleId = (int)value;
            }
        }
        public virtual Role Role { get; set; }
        public ICollection<JobApplication> JobApplications;
        public ICollection<JobOffer> JobOffers;
    }

    public enum Roles
    {
        User = 3,
        HRUser = 4,
        Admin = 5
    }
}
