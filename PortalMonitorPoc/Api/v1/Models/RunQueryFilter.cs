namespace PortalMonitorPoc.Api.v1.Models
{
    public class RunQueryFilter
    {
        public string Operand { get; set; }
        public string Operator { get; set; }
        public List<string> Values { get; set; }
    }
}

