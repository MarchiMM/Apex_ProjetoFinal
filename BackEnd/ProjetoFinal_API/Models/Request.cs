using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "CHAR(1)")]
        [Required]
        public char Status { get; set; }

        [ForeignKey("Person")]
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("Equipament")]
        [Required]
        public int EquipamentId { get; set; }

        [Column(TypeName = "VARCHAR(800)")]
        [Required]
        public string Demand { get; set; }

        [Column(TypeName = "VARCHAR(800)")]
        public string ServiceDescription { get; set; }

        [ForeignKey("Taxation")]
        public int TaxationId { get; set; }

        public Request(int id, char status, int personId, int equipamentId, string demand, string serviceDescription, int taxationId)
        {
            this.Id = id;
            this.Status = status;
            this.PersonId = personId;
            this.EquipamentId = equipamentId;
            this.Demand = demand;
            this.ServiceDescription = serviceDescription;
            this.TaxationId = taxationId;
        }
    }
}