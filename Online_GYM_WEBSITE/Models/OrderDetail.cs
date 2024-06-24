using System;
using System.Collections.Generic;

namespace Online_GYM_WEBSITE.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public int GymMembershipId { get; set; }

    public int UserId { get; set; }

    public virtual GymMembership GymMembership { get; set; } = null!;

    public virtual UserDetail User { get; set; } = null!;
}
