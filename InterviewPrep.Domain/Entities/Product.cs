namespace InterviewPrep.Domain.Entities;

public partial class Product
{
    public long ProductId { get; set; }

    public required string ProductDescription { get; set; }

    public DateTime? DateListed { get; set; }

    public decimal? ProductPrice { get; set; }

    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}
