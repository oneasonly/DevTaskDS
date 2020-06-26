using System;
using System.Collections.Generic;
using System.Reflection;

namespace Logic
{
    public interface IInstanceService
    {
        IEnumerable<Type> GetInstances<T>();
        IEnumerable<Type> GetInstances<T>(Assembly assembly);
        IEnumerable<Type> SearchTypesByName<T>(string PartOfName);
    }
}