using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class Taxation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string TaxDescription { get; set; }

        [Required]
        public double Percentage { get; set; }

        public DateTime EffectiveDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Taxation(int id, string taxDescription, double percentage, DateTime effectiveDate, DateTime expirationDate)
        {
            this.Id = id;
            this.TaxDescription = taxDescription;
            this.Percentage = percentage;
            this.EffectiveDate = effectiveDate;
            this.ExpirationDate = expirationDate;
        }

        public Taxation(int id, string taxDescription, double percentage, DateTime effectiveDate)
        {
            this.Id = id;
            this.TaxDescription = taxDescription;
            this.Percentage = percentage;
            this.EffectiveDate = effectiveDate;
        }
    }
}