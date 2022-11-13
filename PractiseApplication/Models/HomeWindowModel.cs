using PractiseApplication.Models.Entities;
using System.Collections.Generic;

namespace PractiseApplication.Models
{
    class HomeWindowModel
    {
        public User User { get; set; }

        public List<Request> Requests { get; set; }

        public bool ShowOnlyTargetedRequests { get; set; } = true;

        public bool ShowOnlyActiveRequests { get; set; } = true;

        public string Search { get; set; } = string.Empty;

        public int SortIndex { get; set; }

        public RequestStatus StatusFilter { get; set; }
    }
}
