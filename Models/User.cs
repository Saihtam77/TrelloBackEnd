using System;
using System.Collections.Generic;

namespace TrelloBack.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;
}
