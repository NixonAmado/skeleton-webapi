
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers;

public class PersonController : BaseController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public PersonController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        this.unitOfWork = UnitOfWork;
        this.mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var Person = await unitOfWork.Persons.GetAllAsync();
        return mapper.Map<List<PersonDto>>(Person);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonDto>> Get(int id)
    {
        var Person = await unitOfWork.Persons.GetByIdAsync(id);
        if (Person == null){
            return NotFound();
        }
        return this.mapper.Map<PersonDto>(Person);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<PersonDto>> Put(int id, [FromBody] PersonDto _PersonDto)
    {
        if(_PersonDto == null)
        {
            return NotFound();
        }
        var Person = this.mapper.Map<Person>(_PersonDto);
        unitOfWork.Persons.Update(Person);
        await unitOfWork.SaveAsync();
        return _PersonDto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Post(PersonDto _PersonDto)
    {
        var Person = this.mapper.Map<Person>(_PersonDto);
        this.unitOfWork.Persons.Add(Person);
        await unitOfWork.SaveAsync();
        if(unitOfWork == null)
        {
            return BadRequest();
        }
        Person.Id = Person.Id;
        return CreatedAtAction(nameof(Post), new {id = _PersonDto.Id}, _PersonDto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete(int id)
    {
        var Person = await unitOfWork.Persons.GetByIdAsync(id);
        if (Person == null){
            return NotFound();
        }
        unitOfWork.Persons.Remove(Person);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}   
