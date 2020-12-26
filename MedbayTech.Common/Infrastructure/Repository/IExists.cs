using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Repository
{
    public interface IExists<T, ID>
    {
        bool ExistsBy(ID id);
    }
}
