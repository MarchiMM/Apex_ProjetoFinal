using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string Name { get; set; }

        public Company(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}