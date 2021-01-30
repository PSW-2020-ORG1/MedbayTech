
namespace MedbayTech.Common.Repository
{
    public interface IGetBy<T, ID>
    {
        T GetBy(ID id);
    }
}
