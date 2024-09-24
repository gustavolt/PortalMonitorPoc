using Microsoft.AspNetCore.Mvc;
using PortalMonitorPoc.Api.v1.Interfaces;

namespace PortalMonitorPoc.Api.v1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AzureDataFactoryController : ControllerBase
    {
        private readonly IAzureDataFactoryService _azureDataFactoryService;

        public AzureDataFactoryController(IAzureDataFactoryService azureDataFactoryService)
        {
            _azureDataFactoryService = azureDataFactoryService;
        }

        [HttpGet("factories")]
        public async Task<IActionResult> GetDataFactories()
        {
            var factories = await _azureDataFactoryService.GetDataFactoriesAsync();
            return Ok(factories);
        }

        [HttpGet("factories/{factoryName}/pipelines")]
        public async Task<IActionResult> GetPipelineRuns(string factoryName)
        {
            var pipelines = await _azureDataFactoryService.GetPipelineRunsAsync(factoryName);
            return Ok(pipelines);
        }
    }
}
