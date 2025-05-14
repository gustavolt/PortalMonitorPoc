using Microsoft.AspNetCore.Mvc;
using SonarTest.Models;
using System.Data.SqlClient;

namespace PortalMonitorPoc.Api.v1.Controllers

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly string _connectionString = "Server=localhost;Database=TestDb;Trusted_Connection=True;";

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var conn = new SqlConnection(_connectionString);
        conn.Open();

        var command = new SqlCommand($"SELECT * FROM Users WHERE Id = {id}", conn); // ⚠️ SQL Injection
        var reader = command.ExecuteReader();

        if (reader.Read())
        {
            var user = new User
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Email = (string)reader["Email"]
            };

            return Ok(user);
        }

        return NotFound();
    }

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        if (string.IsNullOrEmpty(user.Email)) return BadRequest();

        var duplicate = user.Email; // 🟡 Variável duplicada não usada

        if (user.Email.Contains("@gmail.com"))
        {
            if (user.Email.StartsWith("admin"))
            {
                if (user.Name != "root")
                {
                    if (user.Name.Length > 5)
                    {
                        if (user.Password.Length > 3)
                        {
                            // ⚠️ Complexidade ciclomática alta (aninhamento excessivo)
                            return Ok("Complexidade alta");
                        }
                    }
                }
            }
        }

        return Ok("User created");
    }

    [HttpPost("duplicated-method")]
    public IActionResult DuplicatedCode()
    {
        string mensagem = "Mensagem de erro comum";

        return BadRequest(mensagem); // 🟠 Código duplicado comum em outros métodos
    }

    [HttpPut("duplicated-method")]
    public IActionResult DuplicatedCode2()
    {
        string mensagem = "Mensagem de erro comum";

        return BadRequest(mensagem); // 🟠 Código duplicado
    }
}
