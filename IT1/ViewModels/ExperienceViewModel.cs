using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT1.ViewModels
{
    public class ExperienceViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 10)]
        public string Company { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}
