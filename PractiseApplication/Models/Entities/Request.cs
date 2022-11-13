using System;
using System.Collections.Generic;
using System.Linq;

namespace PractiseApplication.Models.Entities;

public partial class Request
{
    public int Id { get; set; }

    public int? LocationId { get; set; }

    public int? RequestTypeId { get; set; }

    public int? RequestStatusId { get; set; }

    public int? RequesterId { get; set; }

    public int? ExecutionerId { get; set; }

    public string? Title { get; set; }

    public DateTime BeginDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual User? Executioner { get; set; }

    public virtual Location? Location { get; set; }

    public virtual ICollection<RequestChat> RequestChats { get; } = new List<RequestChat>();

    public virtual RequestStatus? RequestStatus { get; set; }

    public virtual RequestType? RequestType { get; set; }

    public virtual User? Requester { get; set; }

    public TimeSpan RequestCompletionTime
    {
        get
        {
            var endTime = EndDate ?? DateTime.Now;

            return endTime - BeginDate;
        }
    }
}
