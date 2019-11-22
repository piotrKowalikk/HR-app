using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HR.DataAccess.Models
{
    public partial class Role
    {
        public Role()
        {
            AppUsers = new HashSet<User>();
        }
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> AppUsers { get; set; }
    }
}
