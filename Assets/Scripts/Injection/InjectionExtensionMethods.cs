using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Injection
{
	public static class InjectionExtensionMethods
	{
		public static void Inject(this MonoBehaviour component)
		{
			// Tries to inject from an Injector Singleton
			if (InjectorSingleton.Instance != null)
			{
				InjectorSingleton.Instance.PerformInjections(component);
			}

			// Tries to inject from individual Injectors on the game object
			foreach (IInjector injector in component.gameObject.GetComponents(typeof(IInjector)))
			{
				injector.PerformAllInjections(component);
			}
		}
	}
}
