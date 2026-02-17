using System;
using System.Collections.Generic;
using InterviewPrep.Domain.Entities;

namespace InterviewPrep.Infrastructure;

public partial class OrderLine
{
    public long OrderLineId { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
