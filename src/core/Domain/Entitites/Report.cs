using Domain.Entities.Commons;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entitites
{
    public class Report : BaseEntity, ICreation
    {
        public Guid? AccountReportedId { get; set; }
        public virtual Account AccountReported { get; set; } = default!;
        public Guid? CreatedBy { get; set; }
        public virtual Account AccountReport { get; set; } = default!;
        public ReportTypeEnum ReportType { get; set; }
        public string Reason { get; set; } = default!;
        public StateEnum State { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
