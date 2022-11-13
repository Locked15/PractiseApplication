using PractiseApplication.Models.Entities;

namespace PractiseApplication.Controllers.Dialogs
{
    class LocationCreationController
    {
        public Location Model { get; set; }

        public LocationCreationController()
        {
            Model = new Location();
        }
    }
}
