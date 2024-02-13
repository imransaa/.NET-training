using assignment.Data.Interfaces;
using assignment.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using NuGet.Protocol;
using System.Linq.Expressions;

namespace assignment.Services
{
    public abstract class GenericService<T, TDto> : IGenericService<T, TDto> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;
        private readonly IMapper _mapper;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }
        
        public virtual IEnumerable<TDto> Get()
        {
            IEnumerable<T> entities = _repository.Get();
            return _mapper.Map<IEnumerable<T>, IEnumerable<TDto>>(entities);
        }

        public virtual TDto Get(int id)
        {
            T entity = _repository.Get(id);
            return _mapper.Map<T, TDto>(entity);
        }

        public virtual TDto Add(TDto request)
        {
            T entity = _mapper.Map<TDto, T>(request);
            _repository.Add(entity);
            _unitOfWork.Save();
            return _mapper.Map<T, TDto>(entity);
        }

        public virtual TDto Update(int id, TDto request)
        {
            T entity = _repository.Get(id);
            entity = _mapper.Map(request, entity);
            _repository.Update(entity);
            _unitOfWork.Save();
            return _mapper.Map<T, TDto>(entity);
        }

        public virtual TDto Delete(int id)
        {
            T entity = _repository.Get(id);
            _repository.Delete(entity);
            _unitOfWork.Save();
            return _mapper.Map<T, TDto>(entity);
        }
    }
}
