
using System.Collections.Generic;

namespace MedbayTech.Common.Repository
{
    public interface IGetAll<T>
    {
        List<T> GetAll();
    }
}
