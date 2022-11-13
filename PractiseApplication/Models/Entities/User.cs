using System;
using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class User
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual ICollection<RequestChat> RequestChats { get; } = new List<RequestChat>();

    public virtual ICollection<Request> RequestExecutioners { get; } = new List<Request>();

    public virtual ICollection<Request> RequestRequesters { get; } = new List<Request>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<UserReview> UserReviews { get; } = new List<UserReview>();

    public string Bind_UserName
    {
        get
        {
            return $"{LastName} {FirstName}";
        }
    }
}
