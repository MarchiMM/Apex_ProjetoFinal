using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public char Status { get; set; }

        [ForeignKey("Client")]
        [Required]
        public int ClientId { get; set; }

        [ForeignKey("Equipament")]
        [Required]
        public int EquipamentId { get; set; }

        [ForeignKey("Employee")]
        [Required]
        public int EmployeeId { get; set; }

        [Column(TypeName = "VARCHAR(800)")]
        [Required]
        public string Order { get; set; }

        [Column(TypeName = "VARCHAR(800)")]
        [Required]
        public string ServiceDescription { get; set; }

        [ForeignKey("Taxation")]
        [Required]
        public int TaxationId { get; set; }

        public Request(int id, char status, int clientId, int equipamentId, int employeeId, string order, string serviceDescription, int taxationId)
        {
            this.Id = id;
            this.Status = status;
            this.ClientId = clientId;
            this.EquipamentId = equipamentId;
            this.EmployeeId = employeeId;
            this.Order = order;
            this.ServiceDescription = serviceDescription;
            this.TaxationId = taxationId;
        }
    }
}