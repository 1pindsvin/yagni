using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using log4net;

namespace ParsePascalDependencies
{
    internal class PascalUnit
    {
        public static readonly PascalUnitComparer UnitComparer = new PascalUnitComparer();

        private static readonly Regex ValidUnitName = new Regex(@"^\w+$");

        private static readonly ILog Log = LogManager.GetLogger(typeof (PascalUnit));

        private readonly string _unitName;

        private const string NotFoundInFilesystem = "not found in filesystem";

        public bool IsValidReference { get; private set; }
        public bool IsFoundInFileSystem { get; private set; }

        internal static PascalUnit CreateInvalidUnitFromPath(string path)
        {
            return new PascalUnit(UnitNameNotFound,path) {IsValidReference = false};
        }

        internal static PascalUnit CreateInvalidUnitWithNameAndPath(string invalidName, string path)
        {
            return new PascalUnit(invalidName,path) {IsValidReference = false};
        }

        internal static PascalUnit CreateUnitWithoutPath(string name)
        {
            if (!IsUnitNameValid(name))
            {
                return CreateInvalidUnit(name);
            }
            var unitWithoutPath = new PascalUnit(name,NotFoundInFilesystem) {IsFoundInFileSystem = false};
            Debug.Assert(!unitWithoutPath.IsFoundInFileSystem);
            return unitWithoutPath;
        }

        internal static PascalUnit CreateInvalidUnit(string name)
        {
            if (!IsUnitNameValid(name))
            {
                if (name.Length > 50)
                {
                    name = name.Substring(0,50);                
                }
                Log.Debug(String.Format(
                        "Name was not resolved for this name [{0}]. Properply an error in parsing of the uses statement CreateInvalidUnit was called!",
                        name));
                name = Guid.NewGuid().ToString();
            }
            return new PascalUnit(name,NotFoundInFilesystem) {IsValidReference = false, IsFoundInFileSystem = false};
        }

        public string UnitNameLowered
        {
            get { return UnitName.ToLower(); }
        }

        public IEnumerable<PascalUnit> DeepReferences
        {
            get
            {
                foreach (var pascalUnit in Units)
                {
                    yield return pascalUnit;
                    foreach (var deepRef in pascalUnit.Units.Where(deepRef => !deepRef.HasSameUnitNameAs(this)))
                    {
                        yield return deepRef;
                    }
                }
            }
        }

        public bool HasSameUnitNameAs(PascalUnit other)
        {
            return UnitNameLowered.Equals(other.UnitNameLowered);
        }

        public List<PascalUnit> Units { get; set; }

        private readonly List<string> _uses;
        private static readonly UnitNameComparer UnitNameComparer = new UnitNameComparer();

        public static bool IsUnitNameValid(string unitName)
        {
            return ValidUnitName.IsMatch(unitName);
        }

        public PascalUnit(string unitName, string path)
        {
            _unitName = unitName;
            if (String.IsNullOrEmpty(unitName))
            {
                throw new UnitNameNotFoundException(path);
            }
            if (!IsUnitNameValid(unitName))
            {
                throw new InvalidOperationException(string.Format("unitName contained invalid chars [{0}]",
                                                                  _unitName));
            }
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentException("path");
            }
            Units = new List<PascalUnit>();
            Path = path;
            IsValidReference = true;
            IsFoundInFileSystem = true;
            _uses = new List<string>();
        }

        public string UnitName
        {
            get { return _unitName; }
        }

        public string Path { get; private set; }

        public void AddUnitNames(IEnumerable<string> unitNames)
        {
            _uses.AddRange(unitNames);
        }

        public IEnumerable<string> DistinctUses
        {
            get { return _uses.Distinct(UnitNameComparer); }
        }

        public static readonly string UnitNameNotFound = "unitname_not_resolved";

        public string DistinctUsesToString()
        {
            return "[" + string.Join("|",
                                     DistinctUses) + "]";
        }

        public override string ToString()
        {
            return string.Format("Unit name: [{0}]" + "Distinct uses: {1}",
                                 UnitName,
                                 DistinctUsesToString());
        }

        public string ToNameAndPathString()
        {
            return string.Format("Name [{0}], Path [{1}]",
                                 UnitName,
                                 Path);
        }
    }
}