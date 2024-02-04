using Domain.Entities.Commons;
using Domain.Enums;

namespace Application.Filters;

public class ArtworkCriteria : BaseCriteria
{
    public Guid? categoryId { set; get; }
    public StateEnum? status { set; get; }
}