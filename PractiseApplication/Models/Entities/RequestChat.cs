using System;
using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class RequestChat
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public int AuthorId { get; set; }

    public string? Message { get; set; }

    public DateTime SentDate { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Request Request { get; set; } = null!;
}
