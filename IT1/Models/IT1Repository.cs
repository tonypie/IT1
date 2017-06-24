using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT1.Models
{
    public class IT1Repository : IIT1Repository
    {
        private IT1Context _context;
        private ILogger<IT1Repository> _logger;

        public IT1Repository(IT1Context context, ILogger<IT1Repository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<Experience> GetAllExperiences()
        {
            _logger.LogInformation("Getting All Experiences from DB");
            return _context.Experiences.ToList();
        }

        public void AddExperience(Experience experience)
        {
            _context.Experiences.Add(experience);
            
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public IEnumerable<Experience> GetExperiencesByUserId(string userId)
        {
            _logger.LogInformation($"Getting Experiences for {userId} from DB");
            return _context.Experiences
                .Where(x => x.UserId == userId)
                .ToList();
        }
    }
}
