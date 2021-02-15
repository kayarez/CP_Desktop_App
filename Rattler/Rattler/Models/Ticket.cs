using System.ComponentModel.DataAnnotations;

namespace Rattler.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(8,ErrorMessage = "Введите не менее 8 символов")]
        public string Passport { get; set; }
        public virtual Trip Trip { get; set; }
        public int TripId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }

        public Ticket ()
        {

        }

        public Ticket (string name, string passport, int tripId, int orderId)
        {
            Name = name;
            Passport = passport;
            TripId = tripId;
            OrderId = orderId;

        }
    }
}
