using System.Runtime.InteropServices;
using Task.Domain.Entites;

namespace Task.Domain.Base
{
    public class CreationEntity<T> : BaseEntity<T>
    {
        public string CreatedById { get; set; }
 
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}