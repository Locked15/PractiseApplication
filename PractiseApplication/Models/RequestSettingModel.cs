using PractiseApplication.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PractiseApplication.Models
{
    class RequestSettingModel
    {
        public Request Request { get; set; }

        public List<RequestChat> Messages { get; set; }


        public List<RequestStatus> Bind_Statuses
        {
            get
            {
                return BaseContext.Instance.RequestStatuses.ToList();
            }
        }

        public List<User> Bind_Executioners
        {
            get
            {
                return BaseContext.Instance.Users.Where(u => u.RoleId >= 2).ToList();
            }
        }
    }
}
