namespace TripPlanner_Construction.Models
{
    public class Proposition
    {
        public int Id { get; set; }

        public int VoyageId { get; set; }

        public int UtilisateurId { get; set; }

        public string TypeProposition { get; set; }

        public string Titre { get; set; }

        public string Description { get; set; }

        public decimal PrixEstime { get; set; }

        public bool EstRetenue { get; set; }
    }
}
