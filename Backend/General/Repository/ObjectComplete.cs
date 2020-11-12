using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.General.Model
{
    public interface ObjectComplete<T>
    {
        void SetMissingValues(T entity);
        void CompleteObject(T entity);
    }
}
