using System.Collections.Generic;

namespace IT1.Models
{
    public interface IIT1Repository
    {
        IEnumerable<Experience> GetAllExperiences();
    }
}