using GUI.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        public string UniqueId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }

    public class UserService : IApplicationUser
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ApplicationUser newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public ApplicationUser Get(string employeeid)
        {
            return GetAll()
                .FirstOrDefault(u => u.UniqueId == employeeid);
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users;
        }
    }
}
