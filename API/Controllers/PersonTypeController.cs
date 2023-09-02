
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers;

public class PersonTypeController : BaseController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PersonTypeController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        this.unitOfWork = UnitOfWork;
        this.mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonTypeDto>>> Get()
    {
        var PersonType = await unitOfWork.PersonTypes.GetAllAsync();
        return mapper.Map<List<PersonTypeDto>>(PersonType);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonTypeDto>> Get(int id)
    {
        var PersonType = await unitOfWork.PersonTypes.GetByIdAsync(id);
        if (PersonType == null){
            return NotFound();
        }
        return this.mapper.Map<PersonTypeDto>(PersonType);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonTypeDto>> Put(int id, [FromBody] PersonTypeDto _PersonTypeDto)
    {
        if(_PersonTypeDto == null)
        {
            return NotFound();
        }
        var PersonType = this.mapper.Map<PersonType>(_PersonTypeDto);
        unitOfWork.PersonTypes.Update(PersonType);
        await unitOfWork.SaveAsync();
        return _PersonTypeDto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonType>> Post(PersonTypeDto _PersonTypeDto)
    {
        var PersonType = this.mapper.Map<PersonType>(_PersonTypeDto);
        this.unitOfWork.PersonTypes.Add(PersonType);
        await unitOfWork.SaveAsync();
        if(unitOfWork == null)
        {
            return BadRequest();
        }
        PersonType.Id = PersonType.Id;
        return CreatedAtAction(nameof(Post), new {id = _PersonTypeDto.Id}, _PersonTypeDto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete(int id)
    {
        var PersonType = await unitOfWork.PersonTypes.GetByIdAsync(id);
        if (PersonType == null){
            return NotFound();
        }
        unitOfWork.PersonTypes.Remove(PersonType);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}   
