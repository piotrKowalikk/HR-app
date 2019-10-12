using System;
using System.Collections.Generic;

namespace HR.DataAccess.Models
{
    public partial class DctRoles
    {
        public DctRoles()
        {
            AppUsers = new HashSet<AppUsers>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<AppUsers> AppUsers { get; set; }
    }
}
