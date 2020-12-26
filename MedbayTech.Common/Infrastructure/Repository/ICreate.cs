using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    public interface ICreate<T>
    {
        T Create(T entity);
    }
}
