using System;
using System.Collections.Generic;
using System.Text;

namespace SimsProjekat.Repository
{
    interface ObjectComplete<T>
    {
        void SetMissingValues(T entity);
        void CompleteObject(T entity);
    }
}
