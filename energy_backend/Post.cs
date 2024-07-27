using System;
using System.Collections.Generic;

namespace energy_backend;

public partial class Post
{
    public string Id { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<PostPhoto> PostPhotos { get; set; } = new List<PostPhoto>();

    public virtual User User { get; set; } = null!;
}
