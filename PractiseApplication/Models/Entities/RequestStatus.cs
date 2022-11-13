using System;
using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class RequestStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
