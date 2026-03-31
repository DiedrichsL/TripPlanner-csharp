using System;
using System.Collections.Generic;

namespace TripPlanner.Entités;

public partial class Participation
{
    public int Id { get; set; }

    public int UtilisateurId { get; set; }

    public int VoyageId { get; set; }

    public string Role { get; set; } = null!;

    public DateOnly DateParticipation { get; set; }

    public virtual Utilisateur Utilisateur { get; set; } = null!;

    public virtual Voyage Voyage { get; set; } = null!;
}
