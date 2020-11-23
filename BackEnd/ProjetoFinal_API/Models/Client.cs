using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal_API.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Person")]
        [Required]
        public int PersonId { get; set; }

        public Client(int id, int personId)
        {
            this.Id = id;
            this.PersonId = personId;
        }
    }
}