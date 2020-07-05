using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// service for work with Type instances and reflection
    /// </summary>
    public class InstanceService
    {
        /// <summary>
        /// Returns an instance of every class of type T in current assembly
        /// </summary>
        /// <typeparam name="T">type of requesting instances</typeparam>
        /// <returns>instances of every class of type T</returns>
        public IEnumerable<Type> GetTypes<T>()
        {
            return GetTypes<T>(Assembly.GetAssembly(typeof(T)));
        }

        /// <summary>
        /// Returns an instance of every class of type T in specified assembly
        /// </summary>
        /// <typeparam name="T">type of requesting instances</typeparam>
        /// <param name="assembly">Specify at which assembly,instances of types required</param>
        /// <returns>instances of every class of type T</returns>
        public IEnumerable<Type> GetTypes<T>(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException();
            var baseType = typeof(T);
            var derivedTypes = assembly.GetTypes()
                .Where(x => baseType.IsAssignableFrom(x));
            return derivedTypes;
        }

        public IEnumerable<T> GetInstances<T>(Assembly assembly) where T : class
        {
            if (assembly == null) throw new ArgumentNullException();

            var types = GetTypes<T>(assembly);
            return GetInstances<T>(types);
        }

        public IEnumerable<T> GetInstances<T>(IEnumerable<Type> types) where T : class
        {
            if (types == null) throw new ArgumentNullException();
            return types.Select(x => Activator.CreateInstance(x) as T);
        }

        public IEnumerable<T> GetInstances<T>() where T : class
        {
            return GetInstances<T>(Assembly.GetAssembly(typeof(T)));
        }

        /// <summary>
        /// Search for types by specifying part of the name
        /// </summary>
        /// <typeparam name="T">type of researching classes</typeparam>
        /// <param name="PartOfName">which contains in T type name</param>
        /// <returns>type instances</returns>
        public IEnumerable<Type> SearchTypesByName<T>(string PartOfName)
        {
            if (string.IsNullOrEmpty(PartOfName)) return Enumerable.Empty<Type>(); //this or commented below
            //if (PartOfName == null) throw new ArgumentNullException();
            var allTypes = GetTypes<T>(Assembly.GetAssembly(typeof(T)));
            var typesByName = allTypes.Where(x => x.Name.ContainsStringComparison(PartOfName));
            return typesByName;
        }

    }
}
