using Microsoft.AspNetCore.Mvc;
using System.Text; // Importação não usada

namespace PortalMonitorPoc.Api.v1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BadController : ControllerBase
    {
        private readonly string _apiKey = "12345-SECRET-KEY"; // Hardcoded secret

        [HttpGet("duplicate")]
        public IActionResult GetDuplicatedLogic()
        {
            int result = 0;
            for (int i = 0; i < 10; i++)
            {
                result += i * 2;
                result += i * 2; // Código duplicado
            }

            int unusedVariable = 42; // Variável não usada

            return Ok(result);
        }

        private void NeverUsedMethod()
        {
            Console.WriteLine("Nunca chamado");
        }
    }
}
