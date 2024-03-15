using Domain.Entities.Commons;
using Domain.Enums;

namespace Application.Filters;

public class ArtworkCriteria : BaseCriteria
{
    public Guid? CategoryId { set; get; }
    public Guid? TagId { set; get; }
    public StateEnum? Status { set; get; }
}