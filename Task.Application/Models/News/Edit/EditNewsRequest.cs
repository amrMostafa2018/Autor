using AutoMapper;
using Task.Application.Common.Mappings;
using Task.Application.Models.News.Add;

namespace Task.Application.Models.News.Edit
{
    public class EditNewsRequest :NewsRequest ,  IMapFrom<Domain.Entites.News>
    {
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Entites.News, EditNewsRequest>().ReverseMap();
        }
    }
}
