using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;
using DetectoristApp.BLL.Exceptions;
using DetectoristApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DetectoristApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoilController : ControllerBase
{
    private readonly ICoilService _coilService;

    public CoilController(ICoilService coilService)
    {
        _coilService = coilService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CoilResponseDTO>>> GetAllAsync()
    {
        var coils = await _coilService.GetAllAsync();
        
        return Ok(coils);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CoilResponseDTO>> GetByIdAsync(int id)
    {
        try
        {
            var coil = await _coilService.GetByIdAsync(id);
            
            return Ok(coil);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CoilResponseDTO>> SaveAsync([FromBody] CoilRequestDTO coilRequestDto)
    {
        var savedCoil = await _coilService.SaveAsync(coilRequestDto);
        
        return CreatedAtAction("GetById", new { id = savedCoil.Id }, savedCoil);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync(int id, [FromBody] CoilRequestDTO coilRequestDto)
    {
        try
        {
            await _coilService.UpdateAsync(coilRequestDto, id);
            
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
            await _coilService.DeleteAsync(id);
            
            return NoContent();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("brand/{brand}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<CoilResponseDTO>>> GetByBrandAsync(string brand)
    {
        var coils = await _coilService.GetByBrandAsync(brand);
        
        return Ok(coils);
    }

    [HttpGet("brandandmodel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CoilResponseDTO>> GetByBrandAndModelAsync([FromQuery] string brand, [FromQuery] string model)
    {
        var coil = await _coilService.GetByBrandAndModelAsync(brand, model);
        
        return Ok(coil);
    }
}
