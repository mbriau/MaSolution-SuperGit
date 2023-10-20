using SuperProjet.Services;

namespace SuperProjet.Models
{
    public class Problem:IModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
    }
}
