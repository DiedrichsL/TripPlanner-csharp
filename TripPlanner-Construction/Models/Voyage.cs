using System.ComponentModel.DataAnnotations;

namespace TripPlanner_Construction.Models
{
    public class Voyage
    {
        public int Id { get; set; }

        [Required]
        public int Organisateurid { get; set; }

        [Required(ErrorMessage = "La destination est obligatoire")]
        public string Destination { get; set; } = null!;

        [Required(ErrorMessage = "La date de début est obligatoire")]
        public DateOnly DateDebut { get; set; }

        [Required(ErrorMessage = "La date de fin est obligatoire")]
        public DateOnly DateFin { get; set; }

        [Required(ErrorMessage = "La date limite de vote est obligatoire")]
        public DateOnly DatelimiteVote { get; set; }

        public string StatutVote { get; set; } = "Ouvert";

        public bool EstActif { get; set; }
    }
}

