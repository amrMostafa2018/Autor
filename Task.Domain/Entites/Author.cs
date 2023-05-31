using Task.Domain.Base;

namespace Task.Domain.Entites
{
    public class Author : AuditEntityWithSoftDelete<int>
    {
        public Author()
        {
            News = new HashSet<News>();
        }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<News> News { get; set; }
    }
}
