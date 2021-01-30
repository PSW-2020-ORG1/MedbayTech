
namespace MedbayTech.Common.Repository
{
    public interface IUpdate<T>
    {
        T Update(T entity);
    }
}
