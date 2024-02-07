using assignment.Dto;
using assignment.Models;
using AutoMapper;

namespace assignment.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<DocumentDto, Document>()
                .ForMember(src => src.Type, opt => opt.Ignore());
        }
    }
}
