using System;
using System.Linq;
using System.Reflection;
using Rifleman.Mobile.Common.Core.Classes;

namespace Rifleman.Mobile.Common.Core.Helpers
{
	public static class EnumsHelper
	{
		public static T GetAttributeOfType<T>( this Enum enumValue ) where T : Attribute
		{
			TypeInfo typeInfo = enumValue.GetType( ).GetTypeInfo( );
			MemberInfo memberInfo = typeInfo.DeclaredMembers.First( x => x.Name == enumValue.ToString( ) );

			return memberInfo.GetCustomAttribute<T>( );
		}

		public static string GetName( this Enum enumVal )
		{
			EnumDescriptionAttribute attr = GetAttributeOfType<EnumDescriptionAttribute>( enumVal );

			return attr?.Name ?? string.Empty;
		}
	}
}
