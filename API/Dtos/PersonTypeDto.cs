
namespace API.Dtos;

    public class PersonTypeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection <PersonDto> Persons { get; set; }
        //public ICollection <RegistrationDto> Registrations { get; set; }


    }
