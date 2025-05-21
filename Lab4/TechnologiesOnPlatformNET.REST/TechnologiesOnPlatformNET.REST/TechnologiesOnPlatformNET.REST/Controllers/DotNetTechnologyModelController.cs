using Microsoft.AspNetCore.Mvc;
using TechnologiesOnPlatformNET.REST.Models;
using TechnologiesOnPlatformNET.REST.Services; 

[ApiController]
[Route("api/[controller]")]
public class DotNetTechnologyModelController : ControllerBase
{
    private readonly DotNetTechnologyCrudService _service; 

    public DotNetTechnologyModelController(DotNetTechnologyCrudService service) 
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.ReadAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var item = await _service.ReadAsync(id);
        return item == null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DotNetTechnologyModelDto dto)
    {
        var result = await _service.CreateAsync(dto);
        await _service.SaveAsync();
        return result ? StatusCode(201) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DotNetTechnologyModelDto dto)
    {
        if (id != dto.Id) return BadRequest();
        var result = await _service.UpdateAsync(dto);
        await _service.SaveAsync();
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var entity = await _service.ReadAsync(id);
        if (entity == null) return NotFound();
        var result = await _service.RemoveAsync(entity);
        await _service.SaveAsync();
        return result ? Ok() : BadRequest();
    }
}