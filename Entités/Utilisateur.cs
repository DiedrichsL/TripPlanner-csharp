using System;
using System.Collections.Generic;

namespace TripPlanner.Entités;

public partial class Utilisateur
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MotDePasse { get; set; } = null!;

    public DateOnly DateInscription { get; set; }

    public virtual ICollection<Participation> Participations { get; set; } = new List<Participation>();

    public virtual ICollection<Proposition> Propositions { get; set; } = new List<Proposition>();

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
