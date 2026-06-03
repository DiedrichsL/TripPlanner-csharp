namespace TripPlanner_Construction.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int UtilisateurId { get; set; }

        public int PropositionId { get; set; }

        public DateTime DateVote { get; set; }

        public bool EstActif { get; set; }
    }
}
