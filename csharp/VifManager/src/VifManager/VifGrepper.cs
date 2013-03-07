using System.Linq;
using System.Collections.Generic;
using System;

namespace dk.magnus.VifManager
{
    internal class VifGrepper<T>
    {
        private readonly Func<VifObject, T> _transformer;

        public VifGrepper(Func<VifObject, T> transformer)
        {
            if (transformer == null)
            {
                throw new ArgumentNullException("transformer");
            }
            _transformer = transformer;
        }

        internal IEnumerable<T> GetDeepVifInfo(VifObject vif)
        {
            yield return _transformer(vif);
            foreach (var info in vif.Children.SelectMany(GetDeepVifInfo))
            {
                yield return info;
            }
        }
    }
}