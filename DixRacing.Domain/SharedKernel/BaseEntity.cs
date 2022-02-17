using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixRacing.Domain.SharedKernel
{
    public class BaseEntity<TId>
    {
        public BaseEntity(TId id)
        {
            Id = id;
        }

        public TId Id { get;set; }

    }
}
