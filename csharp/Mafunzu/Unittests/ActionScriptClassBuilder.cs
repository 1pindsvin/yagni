using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Unittests
{
    public class ActionScriptClassBuilder
    {
        private const string NamespaceTemplate = "package {0}\n{{";

        private const string ClassTemplate = "	public class {0}\n\t{{";
        private const string CloseClassOrInterface = "\t}\n";
        private const string CloseNamespace = "}";

        private const string Constructor =
            "		public function {0}()\n" +
            "		{{" + "\n" +
            "		}}\n";

        private const string InterfaceMethodTemplate = "		function {0}({1}) : {2};\n";


        private const string InterfacePropertyTemplate =
            "		function get {0}() : {1};\n" +
            "		function set {0}(value:{1}) : void;\n";

        private const string InterfaceTemplate = "	public interface {0}\n\t{{";

        private const string MethodTemplate =
            "		public function {0}({1}) : {2}\n" +
            "		{{\n" +
            "		}}\n";

        private const string PropertyTemplate =
            "		private var _{0}:{2};\n\n" +
            "		public function get {1}() : {2}\n" +
            "		{{\n" +
            "			return _{0};\n" +
            "		}}\n\n" +
            "		public function set {1}(value:{2}) : void\n" +
            "		{{\n" +
            "			_{0} = value;\n" +
            "		}}\n";

        private readonly bool _lowerCaseMethodNames;
        private readonly Type _type;
        private readonly StringBuilder _builder;

        public string NamespaceName { get; set; }

        public ActionScriptClassBuilder(Type type)
            : this(type, false)
        {
        }

        public ActionScriptClassBuilder(Type type, bool lowerCaseMethodNames)
        {
            _type = type;
            _lowerCaseMethodNames = lowerCaseMethodNames;
            _builder = new StringBuilder();
            NamespaceName = "dk.runtrack.model";
        }

        public StringBuilder Build()
        {
            return _builder;
        }

        public ActionScriptClassBuilder WithNamespace()
        {
            _builder.Insert(0, string.Format(NamespaceTemplate, NamespaceName) + Environment.NewLine);
            _builder.AppendLine(CloseNamespace);
            return this;
        }

        public ActionScriptClassBuilder BuildActionScriptType()
        {

            if (_type.IsInterface)
            {
                BuildInterface(_builder);
            }
            else
            {
                BuildClass(_builder);
            }
            return this;
        }

        private string LowerCaseFirstCharIfNeeded(string propertyName)
        {
            return _lowerCaseMethodNames ? LowerFirstChar(propertyName) : propertyName;
        }

        private void BuildInterface(StringBuilder builder)
        {
            var interfaze = string.Format(InterfaceTemplate, _type.Name);
            builder.AppendLine(interfaze);
            foreach (var info in _type.GetProperties().Where(x => x.CanWrite))
            {
                var name = info.Name;
                var propertyTypeName = ResolveActionScriptPropertyTypeName(info);
                var property = string.Format(
                    InterfacePropertyTemplate,
                    LowerCaseFirstCharIfNeeded(name),
                    propertyTypeName);
                builder.AppendLine(property);
            }

            BuildMethods(InterfaceMethodTemplate, builder);
            builder.Append(CloseClassOrInterface);
        }

        private void BuildClass(StringBuilder builder)
        {
            var clazz = string.Format(ClassTemplate, _type.Name);
            builder.AppendLine(clazz);

            var constructor = string.Format(Constructor, _type.Name);
            builder.AppendLine(constructor);

            foreach (var info in _type.GetProperties().Where(x => x.CanWrite))
            {
                var name = info.Name;
                var nameFirstCharLower = LowerFirstChar(name);
                var propertyTypeName = ResolveActionScriptPropertyTypeName(info);
                var property = string.Format(
                    PropertyTemplate,
                    nameFirstCharLower,
                    LowerCaseFirstCharIfNeeded(name),
                    propertyTypeName
                    );
                builder.AppendLine(property);
            }
            BuildMethods(MethodTemplate, builder);
            builder.Append(CloseClassOrInterface);
        }

        private void BuildMethods(string methodTemplate, StringBuilder builder)
        {
            Func<MethodInfo, bool> filterPropertiesAndInheritedMethods =
                x => x.DeclaringType == _type && !(x.Name.StartsWith("get_") || x.Name.StartsWith("set_"));
            foreach (
                var methodInfo in _type.GetMethods().
                    Where(filterPropertiesAndInheritedMethods)
                )
            {
                var typeName = ResolveActionScriptPropertyTypeName(methodInfo.ReturnType);
                var parameters = methodInfo.GetParameters();
                var actionScriptParameters = ResolveActionScriptParameters(parameters);
                var parameterArgument = BuildParameterArgument(actionScriptParameters);
                var methodBody = string.Format(
                    methodTemplate,
                    LowerCaseFirstCharIfNeeded(methodInfo.Name),
                    parameterArgument,
                    typeName
                    );
                builder.AppendLine(methodBody);
            }
        }

        private static string BuildParameterArgument(Dictionary<string, string> parameters)
        {
            var arglist = new List<string>();
            foreach (var keyValuePair in parameters)
            {
                var param = keyValuePair.Key + ":" + keyValuePair.Value;
                arglist.Add(param);
            }
            return string.Join(", ", arglist.ToArray());
        }

        private static Dictionary<string, string> ResolveActionScriptParameters(IEnumerable<ParameterInfo> parameters)
        {
            var dic = new Dictionary<string, string>();
            foreach (var info in parameters)
            {
                var name = info.Name;
                var actionScriptTypeName = ResolveActionScriptPropertyTypeName(info.ParameterType);
                dic.Add(name, actionScriptTypeName);
            }
            return dic;
        }

        private static string ResolveActionScriptPropertyTypeName(Type type)
        {
            if (type == typeof (void))
            {
                return "void";
            }
            if (type == typeof (bool))
            {
                return "Boolean";
            }
            if (type == typeof(double))
            {
                return "Number";
            }
            if (type == typeof(uint))
            {
                return "uint";
            }
            if (type == typeof (System.Int32))
            {
                return "int";
            }
            if (type == typeof (System.String))
            {
                return "String";
            }
            if (type == typeof (System.Int64) || type == typeof (System.UInt64))
            {
                return "Number";
            }
            if (type == typeof (DateTime))
            {
                return "Date";
            }
            if (type.FullName ==
                "System.Nullable`1[[System.DateTime, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
            {
                return "Date";
            }
            if (type.FullName ==
                "System.Nullable`1[[System.Int32, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
            {
                return "int";
            }
            if (type.FullName.StartsWith("System.Collections.Generic.IEnumerable`1"))
            {
                return "Array";
            }
            if (type.FullName.StartsWith("System.Collections.Generic.List`1"))
            {
                return "Array";
            }
            if (type.FullName.StartsWith("System.Data.Linq.EntitySet`1"))
            {
                return "Array";
            }

            if (type == typeof (System.Collections.IList))
            {
                return "Array";
            }
            if (type.IsClass)
            {
                return type.Name;
            }
            if (type.IsEnum)
            {
                return type.Name;
            }
            throw new NotImplementedException(type.FullName);
        }

        private static string ResolveActionScriptPropertyTypeName(PropertyInfo info)
        {
            var type = info.PropertyType;
            return ResolveActionScriptPropertyTypeName(type);
        }

        private static string LowerFirstChar(string name)
        {
            if (name.Length == 1)
            {
                return name.ToLower();
            }
            return Char.ToLower(name[0]) + name.Substring(1);
        }
    }
}