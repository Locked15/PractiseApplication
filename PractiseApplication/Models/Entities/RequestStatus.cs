using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class RequestStatus
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public string ColorRgbStringValue
    {
        get
        {
            return Id switch
            {
                // 'Новый' — 'Sky Blue' color.
                1 => "136, 196, 245",
                // 'Важный' — 'Orange' color.
                2 => "232, 105, 18",
                // 'Критический' — 'Dark Red' color.
                3 => "149, 47, 47",
                // 'Отложенный' — 'Gray' color.
                4 => "153, 153, 153",
                // 'Решенный' — 'Dark Green' color.
                5 => "0, 100, 0",

                // In other cases, we return 'Black' color.
                _ => "0, 0, 0",
            };
        }
    }
}
