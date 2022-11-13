using PractiseApplication.Models.Entities;
using System;
using System.Linq;

namespace PractiseApplication.Controllers
{
    class RequestGenerationController
    {
        public Request Model { get; set; }

        public RequestGenerationController()
        {
            var newStatus = BaseContext.Instance.RequestStatuses.First(s => s.Status.StartsWith("Нов"));

            Model = new Request()
            {
                BeginDate = DateTime.Now,
                RequestStatusId = newStatus.Id,
                RequestStatus = newStatus
            };
        }
    }
}
