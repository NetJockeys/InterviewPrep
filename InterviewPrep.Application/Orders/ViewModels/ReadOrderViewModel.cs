namespace InterviewPrep.Application.Orders.ViewModels;

public class ReadOrderViewModel
{
    public long OrderId { get; set; }

    public DateTime? DatePlaced { get; set; }

    public List<ReadOrderLineViewModel> OrderLines { get; set; } = [];
}

