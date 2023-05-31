using System.ComponentModel.DataAnnotations;
using Task.Domain.Base;
using Task.Domain.Enums;

namespace Task.Domain.Entites
{
    public class News : AuditEntityWithSoftDelete<int>
    {
        [MaxLength(100)]
        public string Title { get; set; }
        public string Body { get; set; }
        public NewsType NewsType { get; set; }
        public DateTime? PublishedOn { get; set; }
        public bool IsPublished { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author  { get; set; }

    }
}
