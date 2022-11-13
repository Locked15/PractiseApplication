using System;
using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class UserReview
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public decimal Rate { get; set; }

    public string? Message { get; set; }

    public DateTime ReviewTime { get; set; }

    public virtual User? User { get; set; }
}
