using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Utility
{
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }
    }
}