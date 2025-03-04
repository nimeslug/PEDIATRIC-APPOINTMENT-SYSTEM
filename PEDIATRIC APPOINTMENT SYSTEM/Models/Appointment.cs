using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webOdev.Models
{
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Doctor"), Required]
        public int DoctorId { get; set; } // Hangi doktorla randevu
        [ForeignKey("Assistant")]
        public int AssistantId { get; set; } // Hangi asistanla randevu
        public DateTime Date { get; set; } // Tarih (Gün)
        public TimeSpan Time { get; set; } // Saat (10:00, 11:00 gibi)
        public required string PatientName { get; set; } // Hasta adı
    }
}
