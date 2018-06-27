using Unity;
using Unity.Registration;

namespace Rifleman.Mobile.Common.Core.Extensions
{
	public static class UnityExtensions
	{
		public static void RegisterType<T, TActual, TMock>( this UnityContainer container, string name, params InjectionMember[ ] injectionMembers )
			where TActual : T
			where TMock : T
		{
#if MOCK
			container.RegisterType<T, TMock>( name, injectionMembers );
#else
			container.RegisterType<T, TActual>( name, injectionMembers );
#endif
		}

		public static void RegisterType<T, TActual, TMock>( this UnityContainer container, params InjectionMember[ ] injectionMembers )
			where TActual : T
			where TMock : T
		{
#if MOCK
			container.RegisterType<T, TMock>( injectionMembers );
#else
			container.RegisterType<T, TActual>( injectionMembers );
#endif
		}
	}
}