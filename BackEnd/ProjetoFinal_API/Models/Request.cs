using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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

        public Person Person { get; set; }

        [ForeignKey("Equipment")]
        [Required]
        public int EquipmentId { get; set; }

        public Equipment Equipment { get; set; }

        [Column(TypeName = "VARCHAR(800)")]
        [Required]
        public string Demand { get; set; }

        [Column(TypeName = "VARCHAR(800)")]
        public string ServiceDescription { get; set; }

        public double Value { get; set; }

        public IEnumerable<RequestTaxation> RequestTaxations { get; set; }

        public Request() {}

        public Request(int id, char status, int personId, int equipmentId, string demand, string serviceDescription)
        {
            this.Id = id;
            this.Status = status;
            this.PersonId = personId;
            this.EquipmentId = equipmentId;
            this.Demand = demand;
            this.ServiceDescription = serviceDescription;
        }

        public Request(int id, char status, int personId, int equipmentId, string demand)
        {
            this.Id = id;
            this.Status = status;
            this.PersonId = personId;
            this.EquipmentId = equipmentId;
            this.Demand = demand;
        }
    }
}