using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace kayahome_backend.Contexts.Sets
{
    public class HubConnection : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string ConnectionId { get; set; }

        [Required]
        [StringLength(25)]
        public string UserName { get; set; }
    }
}
