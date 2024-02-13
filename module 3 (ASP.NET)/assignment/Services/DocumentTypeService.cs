using assignment.Data.Interfaces;
using assignment.Dto;
using assignment.Models;
using assignment.Services.Interfaces;
using AutoMapper;

namespace assignment.Services
{
    public class DocumentTypeService : GenericService<DocumentType, TypeDto>, IDocumentTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDocumentTypeRepository _repository;

        public DocumentTypeService(IUnitOfWork unitOfWork, IDocumentTypeRepository repository, IMapper mapper) : base(unitOfWork, repository, mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        public override TypeDto Add(TypeDto request)
        {
            var types = _repository.Get(filter => filter.Type == request.Type);

            if(types.Count() != 0)
            {
                throw new Exception("Document Type already exists");
            }

            return base.Add(request);
        }

        public TypeDto Delete(string typeName)
        {
            var type = _repository.Get(filter => filter.Type == typeName).First();

            if (type == null)
            {
                throw new Exception("type Not Found");
            }

            _repository.Delete(type);
            _unitOfWork.Save();

            return _mapper.Map<TypeDto>(type);
        }
    }
}
