using System;
using System.Collections.Generic;

namespace energy_backend;

public partial class PostPhoto
{
    public string Id { get; set; } = null!;

    public string PostId { get; set; } = null!;

    public string? PhotoUrl { get; set; }

    public virtual Post Post { get; set; } = null!;
}
