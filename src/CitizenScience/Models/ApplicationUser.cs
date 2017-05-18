 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CitizenScience.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Fauna> Faunas { get; set; }
    }

}