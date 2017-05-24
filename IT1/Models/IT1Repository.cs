using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT1.Models
{
    public class IT1Repository : IIT1Repository
    {
        private IT1Context _context;

        public IT1Repository(IT1Context context)
        {
            _context = context;
        }

        public IEnumerable<Experience> GetAllExperiences()
        {
            return _context.Experiences.ToList();
        }
    }
}
