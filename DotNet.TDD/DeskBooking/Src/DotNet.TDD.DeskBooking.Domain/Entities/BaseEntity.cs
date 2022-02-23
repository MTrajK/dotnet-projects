using System.ComponentModel.DataAnnotations;

namespace DotNet.TDD.DeskBooking.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; protected set; }
    }
}
