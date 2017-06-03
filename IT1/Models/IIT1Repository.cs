using System.Collections.Generic;
using System.Threading.Tasks;

namespace IT1.Models
{
    public interface IIT1Repository
    {
        IEnumerable<Experience> GetAllExperiences();
        void AddExperience(Experience experience);
        Task<bool> SaveChangesAsync();
    }
}