using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Task.Application.Common.Mappings;
using Task.Domain.Enums;

namespace Task.Application.Models.News.Add
{
    public class NewsRequest : IMapFrom<Domain.Entites.News>
    {
        [Required(ErrorMessage = "News Title is required")]
        [MaxLength(100,ErrorMessage = "News Title Max Length 100")]
        public string Title { get; set; }
        [Required(ErrorMessage = "News Body is required")]
        public string Body { get; set; }
        public NewsType NewsType { get; set; }
        public DateTime? PublishedOn { get; set; }
        public bool IsPublished { get; set; }
        [Required(ErrorMessage = "News Author is required")]
        public int AuthorId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.News, NewsRequest>().ReverseMap();
        }
    }
}
