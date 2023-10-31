using System.ComponentModel.DataAnnotations;

namespace kayahome_backend.Contexts.Dto
{
    public class UsersDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [MaxLength(2)]
        public string PhoneCountry { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
