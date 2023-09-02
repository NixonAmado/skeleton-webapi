
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers;

public class RegionController : BaseController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public RegionController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        this.unitOfWork = UnitOfWork;
        this.mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RegionDto>>> Get()
    {
        var Region = await unitOfWork.Regions.GetAllAsync();
        return mapper.Map<List<RegionDto>>(Region);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RegionDto>> Get(int id)
    {
        var Region = await unitOfWork.Regions.GetByIdAsync(id);
        if (Region == null){
            return NotFound();
        }
        return this.mapper.Map<RegionDto>(Region);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<RegionDto>> Put(int id, [FromBody] RegionDto _RegionDto)
    {
        if(_RegionDto == null)
        {
            return NotFound();
        }
        var Region = this.mapper.Map<Region>(_RegionDto);
        unitOfWork.Regions.Update(Region);
        await unitOfWork.SaveAsync();
        return _RegionDto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(RegionDto _RegionDto)
    {
        var Region = this.mapper.Map<Region>(_RegionDto);
        this.unitOfWork.Regions.Add(Region);
        await unitOfWork.SaveAsync();
        if(unitOfWork == null)
        {
            return BadRequest();
        }
        Region.Id = Region.Id;
        return CreatedAtAction(nameof(Post), new {id = _RegionDto.Id}, _RegionDto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete(int id)
    {
        var Region = await unitOfWork.Regions.GetByIdAsync(id);
        if (Region == null){
            return NotFound();
        }
        unitOfWork.Regions.Remove(Region);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}   
