

namespace MedbayTech.Common.Repository
{
    public interface IExists<T, ID>
    {
        bool ExistsBy(ID id);
    }
}
