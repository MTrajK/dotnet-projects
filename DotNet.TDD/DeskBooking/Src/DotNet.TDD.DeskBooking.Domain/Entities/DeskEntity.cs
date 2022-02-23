namespace DotNet.TDD.DeskBooking.Domain.Entities
{
    public class DeskEntity : BaseEntity
    {
        public int Floor { get; set; }

        public int Number { get; set; }

        public int Capacity { get; set; }
    }
}
