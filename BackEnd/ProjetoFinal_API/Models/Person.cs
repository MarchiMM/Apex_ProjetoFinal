using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFinal_API.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "CHAR(1)")]
        [Required]
        public char Type { get; set; }

        [Column(TypeName = "CHAR(1)")]
        [Required]
        public char PersonType { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        public string Cpf { get; set; }

        [Column(TypeName = "VARCHAR(12)")]
        public string Cnpj { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        [Required]
        public string Address { get; set; }

        [Column(TypeName = "VARCHAR(16)")]
        [Required]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required]
        public string Email { get; set; }

        public Person(
            int id, 
            char type, 
            char personType, 
            string name, 
            string cpf,
            string address,
            string phoneNumber,
            string email
        )
        {
            this.Id = id;
            this.Type = type;
            this.PersonType = personType;
            this.Name = name;
            this.Cpf = cpf;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public Person(
            int id, 
            char type, 
            char personType, 
            string name, 
            string cnpj,
            int companyId,
            string address,
            string phoneNumber,
            string email
        )
        {
            this.Id = id;
            this.Type = type;
            this.PersonType = personType; 
            this.Name = name;
            this.Cnpj = Cnpj;
            this.CompanyId = companyId;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }
    }
}