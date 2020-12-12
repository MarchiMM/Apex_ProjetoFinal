using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class RequestTaxation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Request")]
        public int RequestId { get; set; }

        public Request Request { get; set; }

        [ForeignKey("Taxation")]
        public int TaxationId { get; set; }

        public Taxation Taxation { get; set; }

        public RequestTaxation(int requestId, int taxationId)
        {
            this.RequestId = requestId;
            this.TaxationId = taxationId;
        }
    }
}