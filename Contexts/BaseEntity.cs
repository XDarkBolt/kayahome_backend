using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace kayahome_backend.Contexts
{
    public class BaseEntity
    {
        [NotNull]
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        [NotNull]
        public DateTime AddDate { get; set; }

        [NotNull]
        public DateTime UpdateDate { get; set; }

        [NotNull]
        public bool IsDeleted { get; set; }
    }
}
