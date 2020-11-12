using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.General.Model
{
    public interface IIdentifiable<ID>
    {
        ID GetId();
        void SetId(ID id);
    }
}
