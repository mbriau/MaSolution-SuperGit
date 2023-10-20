using SuperProjet.Services;

namespace SuperProjet.Models
{
    public class Truc: IModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
    }
}
