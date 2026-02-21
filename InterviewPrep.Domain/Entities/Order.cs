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
        if (OrderLines is List<OrderLine> list)
        {
            list.AddRange(orderLines);
        }
    }
}
