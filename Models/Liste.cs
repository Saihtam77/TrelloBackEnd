using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrelloBack.Models;

public partial class Liste
{
    public int Id { get; set; }

    [Required]
    public string Nom { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public int? ProjetId { get; set; }

    public virtual Projet? Projet { get; set; }

    public virtual ICollection<Tache> Taches { get; set; } = new List<Tache>();
}
