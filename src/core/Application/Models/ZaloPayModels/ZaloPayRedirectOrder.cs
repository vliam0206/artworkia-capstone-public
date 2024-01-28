namespace Application.Models.ZaloPayModels;

public class ZaloPayRedirectOrder
{
    public int Appid { get; set; }
    public string Apptransid { get; set; } = default!;
    public int Pmcid { get; set; }
    public string Bankcode { get; set; } = default!;
    public long Amount { get; set; }
    public long Discountamount { get; set; }
    public int Status { get; set; }
    public string Checksum { get; set; } = default!;
}
