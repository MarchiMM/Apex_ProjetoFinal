using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class Equipament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string Type { get; set; }

        [Column(TypeName = "VARCHAR(40)")]
        [Required]
        public string Brand { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string Model { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string SerialNumber { get; set; }

        public Equipament(int id, string type, string brand, string model, string serialNumber)
        {
            this.Id = id;
            this.Type = type;
            this.Brand = brand;
            this.Model = model;
            this.SerialNumber = serialNumber;
        }
    }
}