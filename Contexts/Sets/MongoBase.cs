using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace kayahome_backend.Contexts.Sets
{
    public class MongoBase
    {
        [Key]
        public ObjectId Id { get; set; }

        [Required]
        [StringLength(25)]
        public string UserName { get; set; }
    }
}
