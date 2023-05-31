using Task.Domain.Entites;

namespace Task.Domain.Base
{
    public interface IAuditEntity
    {
        public DateTime CreationOn { get; set; } 
        public DateTime? ModificationOn { get; set; }
    }
}
