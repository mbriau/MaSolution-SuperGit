using SuperProjet.Data;
using SuperProjet.Models;

namespace SuperProjet.Services
{
    public class ProblemsService : BaseService<Problem>
    {
        public ProblemsService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
