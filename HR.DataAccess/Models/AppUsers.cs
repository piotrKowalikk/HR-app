using System;
using System.Collections.Generic;

namespace HR.DataAccess.Models
{
    public partial class AppUsers :Entity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public virtual DctRoles Role { get; set; }
    }
}
