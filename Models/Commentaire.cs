using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrelloBack.Models;

public partial class Commentaire
{
    public int Id { get; set; }

    [Required]
    public string Contenu { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? TacheId { get; set; }

    public virtual Tache? Tache { get; set; }
}
