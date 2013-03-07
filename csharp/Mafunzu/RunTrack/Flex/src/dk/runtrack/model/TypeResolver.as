package dk.runtrack.model
{
	import flash.utils.*;

	public class TypeResolver
	{
		private static var _ensureUniqueTypeID : Number = 0; 
		public static function getTypeName(value:*):String
		{
			try
			{
				var description:XML = flash.utils.describeType(value);
				var typeName : String = description[0].@name;
				return typeName.replace(/\:\:/g, ".");
			}
			catch(exception:Error)
			{
			}
			//if used for logging, this will throw in logging category -> /[\[\]\~\$\^\&\\(\)\{\}\+\?\/=`!@#%,:;'"<>\s]/
			//return "Unknown type " +  "[" + value + "], unkown types found total [" + _ensureUniqueTypeID + "]";
			return "UnknownTypes" + _ensureUniqueTypeID++;
		
		}
		
		public static function getTypeNameWithoutPackagePrefix(value:*):String
		{
			return classnameWithoutPackagePrefix(getTypeName(value));
		}

		public static function getTypeNameForResourceLookup(value:*):String
		{
			var typename : String = getTypeNameWithoutPackagePrefix(value);
			if(typename.length==1)
			{
				return typename.toLowerCase();
			}
			var firstCharLowered : String =  typename.charAt(0).toLowerCase();
			return firstCharLowered + typename.substr(1);
		}

		
		private static function classnameWithoutPackagePrefix(fullyQualifiedClassname : String) : String
		{
			const SEPARATOR : String = "\.";
			var lastIndexOfSeparator : int = fullyQualifiedClassname.lastIndexOf(SEPARATOR);
			var classnameContainsSeparator : Boolean = lastIndexOfSeparator > 0;
			if(!classnameContainsSeparator)
			{
				return fullyQualifiedClassname;
			}
			var classname : String = fullyQualifiedClassname.substring(lastIndexOfSeparator + 1);
			return classname;	
		}
		
		private static function trimLeft(input:String):String
		{
			if (input == null || input.length == 0)
			{
				return input;
			}
			
			while (input.length > 0 && input.charAt(0) == ' ')
			{
				input = input.substring(1, input.length);
			}
			return input;
		}
	
	}

}


 