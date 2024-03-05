using System.ComponentModel.DataAnnotations;

namespace Application.Models;
public class BlockModel
{
    [Required]
    public Guid BlockedId { get; set; }
}

public class BlockVM
{
    public AccountVM Blocking { get; set; } = default!;
    public AccountVM Blocked { get; set; } = default!;
}

public class BlockingListVM
{
    public Guid Blocking { get; set; } = default!;
    public List<AccountVM> Blockeds { get; set; } = default!;
}