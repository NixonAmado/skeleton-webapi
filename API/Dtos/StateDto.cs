
namespace API.Dtos;

    public class StateDto
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public int IdCountryFk { get; set; }
        public ICollection <RegionDto> Regions { get; set; }

        //public ICollection <RegistrationDto> Registrations { get; set; }


    }
