using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;
using DetectoristApp.BLL.Exceptions;
using DetectoristApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DetectoristApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetaldetectorController : ControllerBase
{
    private readonly IMetaldetectorService _metaldetectorService;

    public MetaldetectorController(IMetaldetectorService metaldetectorService)
    {
        _metaldetectorService = metaldetectorService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MetaldetectorResponseDTO>>> GetAllAsync()
    {
        var metaldetectors = await _metaldetectorService.GetAllAsync();
        
        return Ok(metaldetectors);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MetaldetectorResponseDTO>> GetByIdAsync(int id)
    {
        try
        {
            var metaldetector = await _metaldetectorService.GetByIdAsync(id);
            
            return Ok(metaldetector);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MetaldetectorResponseDTO>> SaveAsync([FromBody] MetaldetectorRequestDTO metaldetectorRequestDto)
    {
        var savedMetaldetector = await _metaldetectorService.SaveAsync(metaldetectorRequestDto);
        
        return CreatedAtAction("GetById", new { id = savedMetaldetector.Id }, savedMetaldetector);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync(int id, [FromBody] MetaldetectorRequestDTO metaldetectorRequestDto)
    {
        try
        {
            await _metaldetectorService.UpdateAsync(metaldetectorRequestDto, id);
            
            return NoContent();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            await _metaldetectorService.DeleteAsync(id);
            
            return NoContent();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("brand/{brand}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MetaldetectorResponseDTO>>> GetByBrandAsync(string brand)
    {
        var metaldetectors = await _metaldetectorService.GetByBrandAsync(brand);
        
        return Ok(metaldetectors);
    }

    [HttpGet("brandandmodel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MetaldetectorResponseDTO>> GetByBrandAndModelAsync([FromQuery] string brand, [FromQuery] string model)
    {
        var metaldetector = await _metaldetectorService.GetByBrandAndModelAsync(brand, model);
        
        return Ok(metaldetector);
    }
}