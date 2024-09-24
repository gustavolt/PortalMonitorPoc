namespace PortalMonitorPoc.Api.v1.Models
{
    public class PipelineRun
    { 
        public string Id { get; set; }
        public string RunId { get; set; }
        public string Status { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
