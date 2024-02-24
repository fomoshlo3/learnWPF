using System.ComponentModel.DataAnnotations;

namespace LAP.Data.Entities
{
    public class CinemaHall
    {
        [Key]
        public int Id { get; set; }

        public int SeatsCount { get; set; }

        public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();

    }
}

