namespace PortalMonitorPoc.Api.v1.Models
{
    public class PipelineRun
    {
        public string RunId { get; set; }
        public string PipelineName { get; set; }
        public Parameters Parameters { get; set; }
        public InvokedBy InvokedBy { get; set; }
        public DateTime RunStart { get; set; }
        public DateTime? RunEnd { get; set; }
        public long? DurationInMs { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> Annotations { get; set; }
        public RunDimension RunDimension { get; set; }
    }

    public class Parameters
    {
        public string OutputBlobNameList { get; set; }
    }

    public class InvokedBy
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class RunDimension
    {
        public string JobId { get; set; }
    }

    public class PipelineRunResponse
    {
        public List<PipelineRun> Value { get; set; }
    }

}
