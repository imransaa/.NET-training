using assignment.Dto;
using assignment.Models;
using AutoMapper;

namespace assignment.Profiles
{
    public class TypeProfile : Profile
    {
        public TypeProfile()
        {
            CreateMap<DocumentType, TypeDto>();
            CreateMap<TypeDto, DocumentType>();
        }
    }
}
