
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers;

public class StateController : BaseController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public StateController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        this.unitOfWork = UnitOfWork;
        this.mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<StateDto>>> Get()
    {
        var State = await unitOfWork.States.GetAllAsync();
        return mapper.Map<List<StateDto>>(State);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<StateDto>> Get(int id)
    {
        var State = await unitOfWork.States.GetByIdAsync(id);
        if (State == null){
            return NotFound();
        }
        return this.mapper.Map<StateDto>(State);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<StateDto>> Put(int id, [FromBody] StateDto _StateDto)
    {
        if(_StateDto == null)
        {
            return NotFound();
        }
        var State = this.mapper.Map<State>(_StateDto);
        unitOfWork.States.Update(State);
        await unitOfWork.SaveAsync();
        return _StateDto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<State>> Post(StateDto _StateDto)
    {
        var State = this.mapper.Map<State>(_StateDto);
        this.unitOfWork.States.Add(State);
        await unitOfWork.SaveAsync();
        if(unitOfWork == null)
        {
            return BadRequest();
        }
        State.Id = State.Id;
        return CreatedAtAction(nameof(Post), new {id = _StateDto.Id}, _StateDto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete(int id)
    {
        var State = await unitOfWork.States.GetByIdAsync(id);
        if (State == null){
            return NotFound();
        }
        unitOfWork.States.Remove(State);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}   
