using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool ContactAgreement { get; set; }
        public string CVurl { get; set; }
        public virtual User User { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
