using System.Linq;
using System.Collections.Generic;
using System;

namespace dk.magnus.VifManager
{
    class VifObjects
    {
        private List<VifObject> _vifs;

        public VifObjects()
        {
            _vifs = new List<VifObject>();
        }

        public void Add(VifObject vif)
        {
            _vifs.Add(vif);
        }
    }
}