using DixRacing.Domain.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Utility
{
    public class Track :BaseEntity
    {
        public byte[] Photo { get; set; }
        public string Name { get; set; }
    }
}