using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class TypesToDiskService : ITypesToDiskService
    {
        /// <summary>
        /// Writes collection of types to a file
        /// </summary>
        /// <param name="types">collection of types</param>
        /// <param name="FilePath">file path on disk</param>
        /// <returns>nothing is returned when it completes</returns>
        public async Task SaveTypes(IEnumerable<Type> types, string FilePath)
        {
            if (types == null) throw new ArgumentNullException(nameof(types));
            if (FilePath == null) throw new ArgumentNullException(nameof(FilePath));

            var list = GetTypesQualifiedNames(types);
            await WriteToDisk(list, FilePath);
        }

        /// <summary>
        /// Writes collection of strings to a file
        /// </summary>
        /// <param name="list">string collection</param>
        /// <param name="FilePath">file path on disk</param>
        /// <returns>nothing is returned when it completes</returns>
        private async Task WriteToDisk(IEnumerable<string> list, string FilePath)
        {
            try
            {
                await Task.Run(() => File.WriteAllLines(FilePath, list));
            }
            catch (IOException ex)
            {
                throw new IOException("IO error occured at writing to disk", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("unhandled exception occured at writing to disk", ex);
            }
        }

        /// <summary>
        /// Gets collection of assembly qualified names from types
        /// </summary>
        /// <param name="types">collection of types</param>
        /// <returns>assembly qualified names</returns>
        private IEnumerable<string> GetTypesQualifiedNames(IEnumerable<Type> types)
        {
            if (types == null) throw new ArgumentNullException();
            return types.Select(x => x.AssemblyQualifiedName);
        }


        public async Task<IEnumerable<Type>> LoadTypes(string FilePath)
        {
            if (FilePath == null) throw new ArgumentNullException(nameof(FilePath));

            var listStrings = await ReadFromDisk(FilePath);
            if (listStrings == null) throw new NullReferenceException(nameof(listStrings));
            var types = listStrings.Select(x => Type.GetType(x));
            return types;
        }

        private async Task<IEnumerable<string>> ReadFromDisk(string FilePath)
        {
            try
            {
                return await Task.Run(() => File.ReadAllLines(FilePath));
            }
            catch (IOException ex)
            {
                throw new IOException("IO error occured at reading from file/disk", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("unhandled exception occured at reading from file/disk", ex);
            }
        }
    }
}
