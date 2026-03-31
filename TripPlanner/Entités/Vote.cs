using System;
using System.Collections.Generic;

namespace TripPlanner.Entités;

public partial class Vote
{
    public int Id { get; set; }

    public int UtilsateurId { get; set; }

    public int PropositionId { get; set; }

    public DateOnly DateVote { get; set; }

    public virtual Proposition Proposition { get; set; } = null!;

    public virtual Utilisateur Utilsateur { get; set; } = null!;
}
