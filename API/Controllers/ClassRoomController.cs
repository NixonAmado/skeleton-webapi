
using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Dominio.Entities;

namespace API.Controllers;

public class ClassRoomController : BaseController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ClassRoomController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        this.unitOfWork = UnitOfWork;
        this.mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClassRoomDto>>> Get()
    {
        var classRoom = await unitOfWork.classRooms.GetAllAsync();
        return mapper.Map<List<ClassRoomDto>>(classRoom);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ClassRoomDto>> Get(int id)
    {
        var classRoom = await unitOfWork.classRooms.GetByIdAsync(id);
        if (classRoom == null){
            return NotFound();
        }
        return this.mapper.Map<ClassRoomDto>(classRoom);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ClassRoomDto>> Put(int id, [FromBody] ClassRoomDto _classRoomDto)
    {
        if(_classRoomDto == null)
        {
            return NotFound();
        }
        var classRoom = this.mapper.Map<ClassRoom>(_classRoomDto);
        unitOfWork.classRooms.Update(classRoom);
        await unitOfWork.SaveAsync();
        return _classRoomDto;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClassRoom>> Post(ClassRoomDto _classRoomDto)
    {
        var classRoom = this.mapper.Map<ClassRoom>(_classRoomDto);
        this.unitOfWork.classRooms.Add(classRoom);
        await unitOfWork.SaveAsync();
        if(unitOfWork == null)
        {
            return BadRequest();
        }
        classRoom.Id = classRoom.Id;
        return CreatedAtAction(nameof(Post), new {id = _classRoomDto.Id}, _classRoomDto);

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> Delete(int id)
    {
        var classRoom = await unitOfWork.classRooms.GetByIdAsync(id);
        if (classRoom == null){
            return NotFound();
        }
        unitOfWork.classRooms.Remove(classRoom);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}   
