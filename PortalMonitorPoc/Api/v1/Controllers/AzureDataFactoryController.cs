using Microsoft.AspNetCore.Mvc;
using PortalMonitorPoc.Api.v1.Interfaces;
using PortalMonitorPoc.Api.v1.Models;

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

        [HttpPost("factories/{factoryName}/pipelines")]
        public async Task<IActionResult> GetPipelineRuns(
         string factoryName,
         [FromBody] PipelineRunQueryParameters queryParameters)
        {
            if (queryParameters == null || queryParameters.Filters == null)
            {
                return BadRequest("Parâmetros de consulta inválidos.");
            }

            var pipelines = await _azureDataFactoryService.GetPipelineRunsAsync(
                factoryName,
                queryParameters.LastUpdatedAfter,
                queryParameters.LastUpdatedBefore,
                queryParameters.Filters
            );

            return Ok(pipelines);
        }
    }
}

