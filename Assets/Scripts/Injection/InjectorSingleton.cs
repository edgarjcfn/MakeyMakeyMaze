using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InjectorSingleton : MonoBehaviour {

	public static InjectorSingleton Instance { get; private set; }

	private List<IInjector> _injectors = new List<IInjector>();

	// Use this for initialization
	void Awake()
	{
		foreach (IInjector injector in GetComponents(typeof(IInjector)))
		{
			_injectors.Add(injector);
		}

		Instance = this;
	}

	public void PerformInjections(MonoBehaviour component)
	{
		foreach (IInjector injector in _injectors)
		{
			injector.PerformAllInjections(component);
		}
	}

	
}
