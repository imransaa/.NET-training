using System.Linq.Expressions;

namespace assignment.Services.Interfaces
{
    public interface IGenericService<T, TDto> where T : class
    {
        IEnumerable<TDto> Get();
        TDto Get(int id);
        TDto Add(TDto request);
        TDto Update(int id, TDto request);
        TDto Delete(int id);
    }
}
