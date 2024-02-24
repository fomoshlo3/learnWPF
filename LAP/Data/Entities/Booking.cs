using System.ComponentModel.DataAnnotations;

namespace LAP.Data.Entities
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public int ScreeningId { get; set; }

        public virtual Screening Screening { get; set; }
    }
}
