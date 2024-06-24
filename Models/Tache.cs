using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrelloBack.Models;

public partial class Tache
{
    public int Id { get; set; }

    [Required]
    public string Nom { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? ListeId { get; set; }

    public virtual ICollection<Commentaire> Commentaires { get; set; } = new List<Commentaire>();

    public virtual Liste? Liste { get; set; }
}
