using ActividadDeportiva.Application.Contract;
using ActividadDeportiva.Application.Dtos.UsuarioDeportivo;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuarioDeportivoController : ControllerBase
{
    private readonly IUsuarioDeportivoService _service;

    public UsuarioDeportivoController(IUsuarioDeportivoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuarios = await _service.ObtenerTodos();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var usuario = await _service.ObtenerPorId(id);
        if (usuario is null)
            return NotFound(new { mensaje = $"Lo siento, el usuario con ID {id} no fue encontrado." });
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UsuarioDeportivoDto dto)
    {
        await _service.Crear(dto);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UsuarioDeportivoDto dto)
    {
        if (id != dto.Id)
            return BadRequest(new { mensaje = "Los IDs no cuadran." });

        var existente = await _service.ObtenerPorId(id);
        if (existente is null)
            return NotFound(new { mensaje = $"Lo siento, el usuario con ID {id} no fue encontrado." });

        await _service.Actualizar(dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existente = await _service.ObtenerPorId(id);
        if (existente is null)
            return NotFound(new { mensaje = $"Lo siento, el usuario con ID {id} no fue encontrado." });

        await _service.Eliminar(id);
        return Ok();
    }
}
