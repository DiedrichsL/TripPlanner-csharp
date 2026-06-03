using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TripPlanner_Construction.Entités;

public partial class Voyage
{
    public int Id { get; set; }

    public int Organisateurid { get; set; }
   
    public string Destination { get; set; } = null!;
    
    public DateOnly DateDebut { get; set; }

    public DateOnly DateFin { get; set; }
    
    public DateOnly DatelimiteVote { get; set; }

    public string StatutVote { get; set; } = "Ouvert";
    public bool EstActif { get; set; }

    public virtual Utilisateur Organisateur { get; set; } = null!;

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();

    public virtual ICollection<Proposition> Propositions { get; set; } = new List<Proposition>();
}
