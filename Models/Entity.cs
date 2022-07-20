using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Entity : IValidatableObject
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        //[DisplayFormat(DataFormatString = "CNP[0-9]{4}")]
        //[RegularExpression(@"^\d{5}-[a-zA-Z]\d$")]
        //egularExpression(@"^\d{13}-[0-9]\d$")]
        public string CNP { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string DenumireCompanie { get; set; }
        [Required]
        public string Judet { get; set; }
        [Required]
        public string Telefon { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public bool Acord { get; set; }
        [Required]
        public bool Market { get; set; } = false;
        [Required]
        public bool ComunicareMail { get; set; } = false;
        [Required]
        public bool ComunicareSMS { get; set; } = false;
        [Required]
        public bool ComunicarePosta { get; set; } = false;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ComunicareMail == false && ComunicareSMS ==false && ComunicarePosta ==false)
            {
                yield return new ValidationResult(
                    $"At least one should be true"
                 );
            }
        }
    }
}
