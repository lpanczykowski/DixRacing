using System;

namespace DixRacing.Domain.Users.Queries
{
    public record UserReadModel(int Id,string Name, string Nick,string Surname)
    {
        [Obsolete("For dapper support only")]
        public UserReadModel() : this(default,default,default,default)
        {
        }
    }
}