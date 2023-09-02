
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers;

public class GenderController : BaseController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GenderController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        this.unitOfWork = UnitOfWork;
        this.mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GenderDto>>> Get()
    {
        var Gender = await unitOfWork.Genders.GetAllAsync();
        return mapper.Map<List<GenderDto>>(Gender);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GenderDto>> Get(int id)
    {
        var Gender = await unitOfWork.Genders.GetByIdAsync(id);
        if (Gender == null){
            return NotFound();
        }
        return this.mapper.Map<GenderDto>(Gender);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<GenderDto>> Put(int id, [FromBody] GenderDto _GenderDto)
    {
        if(_GenderDto == null)
        {
            return NotFound();
        }
        var Gender = this.mapper.Map<Gender>(_GenderDto);
        unitOfWork.Genders.Update(Gender);
        await unitOfWork.SaveAsync();
        return _GenderDto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Gender>> Post(GenderDto _GenderDto)
    {
        var Gender = this.mapper.Map<Gender>(_GenderDto);
        this.unitOfWork.Genders.Add(Gender);
        await unitOfWork.SaveAsync();
        if(unitOfWork == null)
        {
            return BadRequest();
        }
        Gender.Id = Gender.Id;
        return CreatedAtAction(nameof(Post), new {id = _GenderDto.Id}, _GenderDto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete(int id)
    {
        var Gender = await unitOfWork.Genders.GetByIdAsync(id);
        if (Gender == null){
            return NotFound();
        }
        unitOfWork.Genders.Remove(Gender);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}   
