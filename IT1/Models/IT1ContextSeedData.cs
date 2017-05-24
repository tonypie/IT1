using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT1.Models
{
    public class IT1ContextSeedData
    {
        private IT1Context _context;

        public IT1ContextSeedData(IT1Context context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if(!_context.Experiences.Any())
            {
                Experience e = new Experience()
                {
                    Company = "Platinum Funding",
                    Description = "Description of work",
                    EndDate = new DateTime(2006, 10, 27),
                    StartDate = new DateTime(2005, 10, 1),
                    order = 5,
                    SkillsUsed = "ASP.NET, HTML, CSS, Javascript"
                };

                _context.Experiences.Add(e);

                await _context.SaveChangesAsync();
            }
        }
    }
}
