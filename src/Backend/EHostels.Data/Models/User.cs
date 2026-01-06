using System;
using System.Collections.Generic;

namespace EHostels.Data.Models;

public partial class User
{
    public long EntityId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? MobileNumber { get; set; }

    public string Password { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
