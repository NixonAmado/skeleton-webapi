
namespace API.Dtos;

    public class GenderDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection <PersonDto> Persons { get; set; }

    }
