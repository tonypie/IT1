using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT1.Models
{
    public class IT1ContextSeedData
    {
        private IT1Context _context;
        private UserManager<IT1User> _userManager;

        public IT1ContextSeedData(IT1Context context, UserManager<IT1User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {
            if(await _userManager.FindByEmailAsync("tony.pierson@gmail.com") == null)
            {
                var user = new IT1User()
                {
                    UserName = "TonyPie",
                    Email = "tony.pierson@gmail.com"

                };

                await _userManager.CreateAsync(user, "12345Qwerty!");

            }

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
