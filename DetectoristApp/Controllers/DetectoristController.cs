using DetectoristApp.BLL.DTO.Request;
using DetectoristApp.BLL.DTO.Response;
using DetectoristApp.BLL.Exceptions;
using DetectoristApp.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DetectoristApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DetectoristController : ControllerBase
{
    private readonly IDetectoristService _detectoristService;

    public DetectoristController(IDetectoristService detectoristService)
    {
        _detectoristService = detectoristService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DetectoristResponseDTO>>> GetAllAsync()
    {
        var detectorists = await _detectoristService.GetAllAsync();
        return Ok(detectorists);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetectoristResponseDTO>> GetByIdAsync(int id)
    {
        try
        {
            var detectorist = await _detectoristService.GetByIdAsync(id);
            return Ok(detectorist);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetectoristResponseDTO>> SaveAsync([FromBody] DetectoristRequestDTO detectoristRequestDto)
    {
        try
        {
            var inserted = await _detectoristService.SaveAsync(detectoristRequestDto);
            return CreatedAtAction("GetById", new { id = inserted.Id }, inserted);
        }
        catch (InvalidSexException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (UsernameIsTakenException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateAsync(int id, [FromBody] DetectoristRequestDTO detectoristRequestDto)
    {
        try
        {
            await _detectoristService.UpdateAsync(detectoristRequestDto, id);
            return NoContent();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidSexException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (UsernameIsTakenException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        try
        {
            await _detectoristService.DeleteAsync(id);
            
            return NoContent();
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetectoristResponseDTO>> GetByUsernameAsync(string username)
    {
        try
        {
            var detectorist = await _detectoristService.GetByUsernameAsync(username);
            
            return Ok(detectorist);
        }
        catch (EntityNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("sex/{sex}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DetectoristResponseDTO>>> GetBySexAsync(string sex)
    {
        var detectorists = await _detectoristService.GetBySexAsync(sex);
        
        return Ok(detectorists);
    }

    [HttpGet("waterproof")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DetectoristResponseDTO>>> GetWithWaterproofMetaldetectorAsync()
    {
        var detectorists = await _detectoristService.GetWithWaterproofMetaldetectorAsync();
        
        return Ok(detectorists);
    }

    [HttpGet("metaldetector/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DetectoristResponseDTO>>> GetByMetaldetectorAsync(int id)
    {
        var detectorists = await _detectoristService.GetByMetaldetectorAsync(id);
        
        return Ok(detectorists);
    }

    [HttpGet("coil/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DetectoristResponseDTO>>> GetByCoilAsync(int id)
    {
        var detectorists = await _detectoristService.GetByCoilAsync(id);
        
        return Ok(detectorists);
    }
}
