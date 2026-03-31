using System;
using System.Collections.Generic;

namespace TripPlanner.Entités;

public partial class Proposition
{
    public int Id { get; set; }

    public int VoyageId { get; set; }

    public int UtilisateurId { get; set; }

    public string TypeProposition { get; set; } = null!;

    public string Titre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal PrixEstime { get; set; }

    public bool EstRetenue { get; set; }

    public virtual Utilisateur Utilisateur { get; set; } = null!;

    public virtual ICollection<Vote> Votes { get; set; } = new List<Vote>();

    public virtual Voyage Voyage { get; set; } = null!;
}
