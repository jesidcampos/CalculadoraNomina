using Microsoft.AspNetCore.Mvc;
using CalculadoraNomina.Models;
using CalculadoraNomina.Services;

namespace CalculadoraNomina.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NominaController : ControllerBase
    {
        private readonly NominaService _service;

        public NominaController(NominaService service)
        {
            _service = service;
        }

        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] Empleado emp)
        {
            if (emp == null || emp.SalarioBasico <= 0)
                return BadRequest(new { error = "Datos inválidos"});

            var resultado = _service.CalculadoraNomina(emp);
            return Ok(resultado);
        }
    }
}