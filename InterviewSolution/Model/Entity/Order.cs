using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSolution.Model.Entity
{
    [Table(name: "orders")]
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

        public override bool Equals(object? obj)
        {
            return obj is Order order &&
                   Id == order.Id &&
                   CitySender == order.CitySender &&
                   AddressSender == order.AddressSender &&
                   CityRecipient == order.CityRecipient &&
                   AddressRecipient == order.AddressRecipient &&
                   CargoWeight == order.CargoWeight &&
                   ReceiptDateTime == order.ReceiptDateTime;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, CitySender, AddressSender, CityRecipient, AddressRecipient, CargoWeight, ReceiptDateTime);
        }

        public override string? ToString()
        {
            return String.Format(
                "[" +
                "Id={0}; " +
                "CitySender=\"{1}\"; " +
                "AddressSender=\"{2}\"; " +
                "CityRecipient=\"{3}\"; " +
                "AddressRecipient=\"{4}\"; " +
                "CargoWeight={5}; " +
                "ReceiptDateTime=\"{6}\"" +
                "]",
                Id,
                CitySender,
                AddressSender,
                CityRecipient,
                AddressRecipient, 
                CargoWeight,
                ReceiptDateTime
            );
        }
    }
}
