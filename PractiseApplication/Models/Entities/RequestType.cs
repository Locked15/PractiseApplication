using System;
using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class RequestType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
