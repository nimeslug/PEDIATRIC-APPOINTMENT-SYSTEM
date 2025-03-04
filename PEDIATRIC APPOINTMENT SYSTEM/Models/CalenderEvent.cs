using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using webOdev.Models;

namespace WEBPRO.Models
{
    public class CalenderEvent
    {
        public string Id { get; set; }
        public DateTime Date { get; set; } // Tarih (Gün)
        public TimeSpan Time { get; set; } // Saat (10:00, 11:00 gibi)
    }
}
