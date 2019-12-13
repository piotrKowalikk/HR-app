using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HR.DataAccess.Models
{
    public class JobApplication : Entity
    {
        [Key]
        public int Id { get; set; }
        public int JobOfferId { get; set; }
        public int UserId { get; set; }

        [DisplayName("Firstname")]
        public string FirstName { get; set; }

        [DisplayName("Last edit")]
        public DateTime ApplicationDate { get; set; }

        [DisplayName("Lastname")]
        public string LastName { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        [DisplayName("Enable phone contact")]
        public bool ContactAgreement { get; set; }

        public string CVurl { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
