using System;
using System.Collections.Generic;

namespace FitnessTracker.Infrastructure.Models;

public partial class Gender
{
    public string Value { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
