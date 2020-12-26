using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    public interface IGetAll<T>
    {
        List<T> GetAll();
    }
}
