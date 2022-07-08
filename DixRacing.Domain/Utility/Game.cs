using DixRacing.Domain.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace DixRacing.Domain.Utility
{
    public class Game:BaseEntity
    {
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}