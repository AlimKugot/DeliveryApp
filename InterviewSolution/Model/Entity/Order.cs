using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSolution.Model.Entity
{
    [Table(name:"orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CitySender { get; set; } = string.Empty;

        [Required]
        public string AddressSender { get; set; } = string.Empty;

        [Required]
        public string CityRecipient { get; set; } = string.Empty;


        [Required]
        public string AddressRecipient { get; set; } = string.Empty;


        [Required]
        public float CargoWeight { get; set; } = 0.0f;


        [Required]
        public DateTime ReceiptDateTime { get; set; }

    }
}
