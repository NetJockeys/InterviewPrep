namespace InterviewPrep.Application.ViewModels;

public partial class ReadProductViewModel
{
    public long ProductId { get; set; }
    public string? ProductDescription { get; set; }
    public DateTime? DateListed { get; set; }
    public decimal? ProductPrice { get; set; }
}

