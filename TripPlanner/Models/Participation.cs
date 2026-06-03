namespace TripPlanner_Construction.Models
{
    public class Participation
    {
        public int Id { get; set; }

        public int UtilisateurId { get; set; }

        public int VoyageId { get; set; }

        public string Role { get; set; }

        public DateTime DateParticipation { get; set; }
    }
}
