using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI.Models
{
    interface IApplicationUser
    {
        ApplicationUser Get(string employeeid);

        void Add(ApplicationUser newUser);

        IEnumerable<ApplicationUser> GetAll();
    }
}
