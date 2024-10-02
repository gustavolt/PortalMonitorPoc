using PortalMonitorPoc.Api.v1.Models;

namespace PortalMonitorPoc.Api.v1.Interfaces
{
    public interface IAzureDataFactoryService
    {
        Task<List<DataFactory>> GetDataFactoriesAsync();
        Task<List<PipelineRun>> GetPipelineRunsAsync(string dataFactoryName, DateTime lastUpdatedAfter, DateTime lastUpdatedBefore, List<RunQueryFilter> filters);
    }
}
