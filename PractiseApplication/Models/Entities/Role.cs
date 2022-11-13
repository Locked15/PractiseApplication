﻿using System;
using System.Collections.Generic;

namespace PractiseApplication.Models.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
