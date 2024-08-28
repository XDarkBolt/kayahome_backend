using System.ComponentModel.DataAnnotations;

namespace kayahome_backend.Contexts.Dto
{
    public record UsersDto
    (
        string Name,
        string SurName,
        string UserId,
        string Password,
        string Email,
        [MaxLength(2)]
        string PhoneCountry,
        [MaxLength(10)]
        string PhoneNumber
    );
}
