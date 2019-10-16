using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.DataAccess.Models
{
    public partial class AppUsers :Entity
    {
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
        public virtual DctRoles Role { get; set; }
    }

    public enum Roles
    {
        User = 1,
        HRUser = 2,
        Admin = 3
    }
}
