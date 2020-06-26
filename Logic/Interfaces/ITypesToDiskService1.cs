using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic
{
    public interface ITypesToDiskService
    {
        Task<IEnumerable<Type>> LoadTypes(string FilePath);
        Task SaveTypes(IEnumerable<Type> types, string FilePath);
    }
}