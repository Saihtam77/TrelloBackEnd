﻿using System;
using System.Collections.Generic;

namespace TrelloBack.Models;

public partial class Projet
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Liste> Listes { get; set; } = new List<Liste>();
}
