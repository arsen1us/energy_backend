using System;
using System.Collections.Generic;

namespace energy_backend;

public partial class User
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Address { get; set; }

    public string? PhotoUrl { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
