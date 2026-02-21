namespace InterviewPrep.Infrastructure.OrderContracts;

public class ReadOrderContract
{
    public long OrderId { get; set; }

    public DateTime? DatePlaced { get; set; }

    public List<ReadOrderLineContract> OrderLines { get; set; } = [];
}

public class ReadOrderLineContract
{
    public long OrderLineId { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    public string? ProductDescription { get; set; }
}