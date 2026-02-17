using System;
using System.Collections.Generic;

namespace InterviewPrep.Infrastructure;

public partial class Order
{
    public long OrderId { get; set; }

    public DateTime? DatePlaced { get; set; }

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
