using System.Linq;
using System.Collections.Generic;
using System;

namespace dk.magnus.VifManager
{
    class VifObject
    {
        private readonly List<string> _lines;
        private readonly List<VifObject> _children;
        private VifObject _parent;

        public bool IsEmpty 
        {
            get { return !HasBeginOfObjectLine; }
        }

        public bool HasBeginOfObjectLine { get; private set; }

        public bool HasEndOfObjectLine { get; private set; }


        internal void AddEndOfObjectLine(string line)
        {
            AddLine(line);
            HasEndOfObjectLine = true;
        }

        internal void AddBeginObjectLine(string line)
        {
            AddLine(line);
            HasBeginOfObjectLine = true;
        }

        public bool IsRoot { get; set; }

        internal VifObject()
        {
            HasBeginOfObjectLine = false;
            HasEndOfObjectLine = false;
            _children = new List<VifObject>();
            _lines = new List<string>();
        }

        internal void AddLine(string line)
        {
            _lines.Add(line);
        }

        private void AddChild(VifObject vif)
        {
            _children.Add(vif);
        }

        internal IEnumerable<string> Lines
        {
            get { return _lines; }
        }

        public IEnumerable<VifObject> Children
        {
            get { return _children; }
        }

        public VifObject Parent
        {
            get { return _parent; }
            set
            {
                if (IsRoot)
                {
                    throw new InvalidOperationException("cannot add parent to root");
                }
                _parent = value;
               _parent.AddChild(this);
            }
        }

        public bool HasChildren {
            get { return _children.Count > 0; }
        }
    }
}