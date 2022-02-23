using System.ComponentModel.DataAnnotations;

namespace DotNet.TDD.DeskBooking.Domain.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }
    }
}