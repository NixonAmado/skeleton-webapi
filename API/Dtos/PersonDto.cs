
namespace API.Dtos;

    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int IdGenderFk { get; set; }
        public int IdPersonTypeFk { get; set; }
        public int IdRegionFk { get; set; }
        public ICollection <ClassRoomDto> ClassRooms { get; set; }
        //public ICollection <RegistrationDto> Registrations { get; set; }


    }
