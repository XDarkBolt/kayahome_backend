using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace kayahome_backend.Contexts.Sets
{
    [Index(nameof(UserId), IsUnique = true)]
    public class Users : BaseEntity
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        [Required]
        [StringLength(25)]
        public string UserId { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        [MaxLength(2)]
        public string PhoneCountry { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }
    }
}
