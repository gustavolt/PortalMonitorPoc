namespace PortalMonitorPoc.Api.v1.Models
{
    public class DataFactoryResponse
    {
        public List<DataFactory> Value { get; set; }
    }
    public class DataFactory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
