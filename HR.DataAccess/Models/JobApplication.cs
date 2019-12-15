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
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last edit")]
        public DateTime ApplicationDate { get; set; }

        [DisplayName("Lastname")]
        [Required]
        public string LastName { get; set; }

        [DisplayName("Phone number")]
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Your phone number should be 9 characters long and contain only numbers.")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("Enable phone contact")]
        public bool ContactAgreement { get; set; }

        [DisplayName("CV")]
        public string CVurl { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
