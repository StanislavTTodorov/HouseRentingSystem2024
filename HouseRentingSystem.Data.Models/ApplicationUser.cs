using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Data.Models
{
    /// <summary>
    /// This is custom user class that works with the defaut ASP.NET Core Identiry. 
    /// You can add additional info to the built-in users.
    /// </summary>
    public class ApplicationUser:IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.RentedHouses = new HashSet<House>();
        }

        public ICollection<House> RentedHouses { get; set; }
    }
}
