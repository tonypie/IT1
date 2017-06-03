using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace IT1.Models
{
    public class IT1User : IdentityUser
    {
        public DateTime Created { get; set; }
    }
}