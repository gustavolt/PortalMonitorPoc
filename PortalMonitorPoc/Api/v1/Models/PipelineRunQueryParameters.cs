using System;
namespace PortalMonitorPoc.Api.v1.Models
{
    public class PipelineRunQueryParameters
    {
        public DateTime LastUpdatedAfter { get; set; }
        public DateTime LastUpdatedBefore { get; set; }
        public List<RunQueryFilter> Filters { get; set; }
    }

}

