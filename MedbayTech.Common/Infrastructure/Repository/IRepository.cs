
using MedbayTech.Common.Domain.Entities;
using System;

namespace MedbayTech.Common.Repository
{
    public interface IRepository<T, ID> : ICreate<T>, IUpdate<T>, IDelete<T>, IGetBy<T, ID>, IGetAll<T>, IExists<T, ID>
        where T : IIdentifiable<ID>
        where ID : IComparable
    {
    }
}
