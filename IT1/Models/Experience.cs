using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT1.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SkillsUsed { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
