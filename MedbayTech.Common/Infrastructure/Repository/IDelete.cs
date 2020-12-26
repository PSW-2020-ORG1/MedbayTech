using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    public interface IDelete<T>
    {
        bool Delete(T entity);
    }
}
