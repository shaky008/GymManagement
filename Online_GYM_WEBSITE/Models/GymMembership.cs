using System;
using System.Collections.Generic;

namespace Online_GYM_WEBSITE.Models;

public partial class GymMembership
{
    public int GymMembershipId { get; set; }

    public string MembershipType { get; set; } = null!;

    public int MembershipLength { get; set; }

    public int MembershipCost { get; set; }

    public string MembershipDetail { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
