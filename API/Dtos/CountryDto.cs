
namespace API.Dtos;

    public class CountryDto
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public ICollection <StateDto> States { get; set; }
    }
