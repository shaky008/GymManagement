using System;
using System.Collections.Generic;

namespace Online_GYM_WEBSITE.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public int UserNumber { get; set; }

    public string UserName { get; set; } = null!;

    public string UserType { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
