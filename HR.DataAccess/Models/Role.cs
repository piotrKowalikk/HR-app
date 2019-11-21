using System;
using System.Collections.Generic;

namespace HR.DataAccess.Models
{
    public partial class Role
    {
        public Role()
        {
            AppUsers = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<User> AppUsers { get; set; }
    }
}
