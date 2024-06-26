using System;
using System.Collections.Generic;

namespace TrelloBack.Models;

public partial class Commentaire
{
    public int Id { get; set; }

    public string Contenu { get; set; } = null!;

    public DateOnly? CreatedAt { get; set; }

    public int? TacheId { get; set; }

    public virtual Tache? Tache { get; set; }
}
