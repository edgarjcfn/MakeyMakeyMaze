using UnityEngine;
using System.Collections;
using System.Reflection;

public class BaseInjector<T> : MonoBehaviour, IInjector
	where T : System.Attribute
{
	public void Awake()
	{
		
	}

	public virtual void PerformAllInjections(MonoBehaviour component)
	{
		var fields = component.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

		foreach (FieldInfo field in fields)
		{
			var attributes = field.GetCustomAttributes(true);

			foreach (var attribute in attributes)
			{
				if (attribute is T)
				{
					PerformInjection((T)attribute, field, component);
				}
			}
		}
	}

	void IInjector.PerformAllInjections(MonoBehaviour component)
	{
		PerformAllInjections(component);
	}

	protected virtual void PerformInjection(T attribute, FieldInfo field, MonoBehaviour component)
	{

	}
}
