using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;

namespace Unittests
{
    public class ScriptTypeSearcher
    {
        private readonly IEnumerable<Assembly> _searchAssemblies;

        public ScriptTypeSearcher() : this(new[] {Assembly.GetExecutingAssembly()})
        {
        }

        public ScriptTypeSearcher(IEnumerable<Assembly> searchAssemblies)
        {
            if (searchAssemblies == null)
            {
                throw new ArgumentNullException("searchAssemblies");
            }
            _searchAssemblies = searchAssemblies;
        }

        public IEnumerable<Type> GetTypesWithTableAttribute()
        {
            foreach (var assembly in _searchAssemblies)
            {
                foreach (var type in GetTypesWithTableAttribute(assembly))
                {
                    yield return type;
                }
            }
        }

        public IEnumerable<Type> GetTypesWithTableAttribute(Assembly assembly)
        {
            const bool searchInheritedAttributes = true;
            return assembly.GetTypes().
                Where(type => type.GetCustomAttributes(searchInheritedAttributes).
                                  Where(attribute => attribute is TableAttribute).FirstOrDefault() != null);
        }
    }
}