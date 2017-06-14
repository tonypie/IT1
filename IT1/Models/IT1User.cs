using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace IT1.Models
{
    public class IT1User : IdentityUser
    {
        [Required]
        public DateTime Created { get; set; }
    }
}