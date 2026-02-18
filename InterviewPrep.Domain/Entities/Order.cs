using InterviewPrep.Infrastructure;

namespace InterviewPrep.Domain.Entities;

public partial class Order
{
    public long OrderId { get; set; }

    public DateTime? DatePlaced { get; set; }

    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public void AddOrderLine(OrderLine orderLine)
    {
        OrderLines.Add(orderLine);
    }

    public void AddOrderLines(IEnumerable<OrderLine> orderLines)
    {
        foreach (var line in orderLines)
        {
            OrderLines.Add(line);
        }
    }
}
