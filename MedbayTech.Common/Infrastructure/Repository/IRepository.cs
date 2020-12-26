using MedbayTech.Repository.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    public interface IRepository<T, ID> : ICreate<T>, IUpdate<T>, IDelete<T>, IGetBy<T, ID>, IGetAll<T>, IExists<T, ID>
        where T : IIdentifiable<ID>
        where ID : IComparable
    {
    }
}
