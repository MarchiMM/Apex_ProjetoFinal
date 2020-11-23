using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Person")]
        [Required]
        public int PersonId { get; set; }

        public Employee(int id, int personId)
        {
            this.Id = id;
            this.PersonId = personId;
        }
    }
}