
namespace MedbayTech.Common.Repository
{
    public interface ICreate<T>
    {
        T Create(T entity);
    }
}
