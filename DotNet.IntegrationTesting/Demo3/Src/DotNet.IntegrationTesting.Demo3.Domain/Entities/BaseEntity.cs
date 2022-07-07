
namespace DotNet.IntegrationTesting.Demo3.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; protected set; }
    }
}