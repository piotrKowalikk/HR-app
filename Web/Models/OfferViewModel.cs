using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_OpenIDConnect_DotNet.Models
{
    public class OfferViewModel
    {
        public int Id { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public string UserId { get; set; }

        public string Description { get; set; }

        public int? SalaryFrom { get; set; }

        public int? SalaryTo { get; set; }

        public bool IsActive { get; set; }

        public DateTime DatePosted { get; set; }

        public DateTime DateExpiration { get; set; }

    }
}
