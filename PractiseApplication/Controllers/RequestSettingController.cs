using PractiseApplication.Models;
using PractiseApplication.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PractiseApplication.Controllers
{
    class RequestSettingController
    {
        public RequestSettingModel Model { get; set; }

        public RequestSettingController()
        {
            Model = new RequestSettingModel();
        }

        public RequestSettingController(Request request, List<RequestChat> chats)
        {
            Model = new()
            {
                Request = request,
                Messages = chats
            };
        }

        public void UpdateMessages() =>
               Model.Messages = BaseContext.Instance.RequestChats.Where(rc => rc.RequestId == Model.Request.Id).ToList();

        public RequestStatus? GetStatusById(int? statusId) =>
               BaseContext.Instance.RequestStatuses.FirstOrDefault(rc => rc.Id == statusId);
    }
}
