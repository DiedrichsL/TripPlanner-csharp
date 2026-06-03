using System.ComponentModel.DataAnnotations;

namespace TripPlanner_Construction.Models
{
    public class Voyage
    {
        public int Id { get; set; }

        [Required]
        public int Organisateurid { get; set; }

        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }


        [Required]
        public DateTime DateFin { get; set; }
        [Required]
        public DateTime DateLimiteVote { get; set; }
        [Required]
        public string StatutVote { get; set; }
    }
}

