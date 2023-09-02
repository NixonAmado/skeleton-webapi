
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers;

public class CountryController : BaseController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CountryController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        this.unitOfWork = UnitOfWork;
        this.mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var Country = await unitOfWork.Countries.GetAllAsync();
        return mapper.Map<List<CountryDto>>(Country);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var Country = await unitOfWork.Countries.GetByIdAsync(id);
        if (Country == null){
            return NotFound();
        }
        return this.mapper.Map<CountryDto>(Country);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto _CountryDto)
    {
        if(_CountryDto == null)
        {
            return NotFound();
        }
        var Country = this.mapper.Map<Country>(_CountryDto);
        unitOfWork.Countries.Update(Country);
        await unitOfWork.SaveAsync();
        return _CountryDto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(CountryDto _CountryDto)
    {
        var Country = this.mapper.Map<Country>(_CountryDto);
        this.unitOfWork.Countries.Add(Country);
        await unitOfWork.SaveAsync();
        if(unitOfWork == null)
        {
            return BadRequest();
        }
        Country.Id = Country.Id;
        return CreatedAtAction(nameof(Post), new {id = _CountryDto.Id}, _CountryDto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete(int id)
    {
        var Country = await unitOfWork.Countries.GetByIdAsync(id);
        if (Country == null){
            return NotFound();
        }
        unitOfWork.Countries.Remove(Country);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}   
