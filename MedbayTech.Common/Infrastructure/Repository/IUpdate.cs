using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    public interface IUpdate<T>
    {
        T Update(T entity);
    }
}
