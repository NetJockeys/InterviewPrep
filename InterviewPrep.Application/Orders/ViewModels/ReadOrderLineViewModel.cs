namespace InterviewPrep.Application.Orders.ViewModels;

public class ReadOrderLineViewModel
{
    public long OrderLineId { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public int Quantity { get; set; }

    public string? ProductDescription { get; set; }
}