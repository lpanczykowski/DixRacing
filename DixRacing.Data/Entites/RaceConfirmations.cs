using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DixRacing.Data.Entites
{
    public class RaceConfirmations
    {
        [Key]
        public int RaceConfirmationId { get; set; }
        public int UserId { get; set; }
        public int RaceId { get; set; }
        public int Confrimed { get; set; }
    }
}