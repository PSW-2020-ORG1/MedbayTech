using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Repository
{
    public interface IIdentifiable<ID>
    {
        ID GetId();
        void SetId(ID id);
    }
}
