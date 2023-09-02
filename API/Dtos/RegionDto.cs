
namespace API.Dtos;

    public class RegionDto
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        public int IdStateFk { get; set; }
        public ICollection <PersonDto> Persons { get; set; }

        //public ICollection <RegistrationDto> Registrations { get; set; }


    }
