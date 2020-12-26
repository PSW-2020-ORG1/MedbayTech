using System;
using System.Collections.Generic;
using System.Text;

namespace MedbayTech.Repository.Domain.Entities
{
    public interface IIdentifiable<ID>
    {
        ID GetId();
    }
}
