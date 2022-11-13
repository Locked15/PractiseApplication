using System;
using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class Location
{
    public int Id { get; set; }

    public string Municipality { get; set; } = null!;

    public int Floor { get; set; }

    public int Cabinet { get; set; }

    public int? Table { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();

    public string Bind_ComplexValue
    {
        get
        {
            var temp = $"{Municipality} -> {Cabinet}";
            if (Table != null)
                temp += $" -> {Table}";

            return temp;
        }
    }
}
