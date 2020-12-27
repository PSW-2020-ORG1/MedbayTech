

namespace MedbayTech.Common.Repository
{
    public interface IDelete<T>
    {
        bool Delete(T entity);
    }
}
