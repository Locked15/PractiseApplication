using PractiseApplication.Models;
using PractiseApplication.Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PractiseApplication.Controllers
{
    class HomeWindowController
    {
        public HomeWindowModel Model { get; set; }

        public HomeWindowController()
        {
            Model = new HomeWindowModel();
        }

        public void UpdateRequests() =>
               Model.Requests = GetAvailableRequests();

        public List<Request> GetAvailableRequests()
        {
            return Model.User.RoleId switch
            {
                1 => Model.Requests = BaseContext.Instance.Requests.Where(req => req.RequesterId == Model.User.Id).ToList(),
                2 => Model.Requests = BaseContext.Instance.Requests.Where(req => req.ExecutionerId == Model.User.Id).ToList(),
                3 => Model.Requests = BaseContext.Instance.Requests.ToList(),

                _ => Enumerable.Empty<Request>().ToList()
            };
        }
    }
}
