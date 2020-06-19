using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string roleName) : base(roleName)
        {

        }

        public ApplicationRole(string roleName, string _description, DateTime _creationDate) : base(roleName)
        {
            Description = _description;
            CreationDate = _creationDate;

        }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
