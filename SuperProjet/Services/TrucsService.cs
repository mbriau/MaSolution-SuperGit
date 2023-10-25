using SuperProjet.Data;
using SuperProjet.Models;

namespace SuperProjet.Services
{
    public class TrucsService : BaseService<Truc>
    {
        public TrucsService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
