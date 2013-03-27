using UnityEngine;
using System.Collections;
using System.Reflection;

public class InjectFromPlayerPrefs : BaseInjector<InjectFromPlayerPrefsAttribute>
{
	protected override void PerformInjection(InjectFromPlayerPrefsAttribute attribute, FieldInfo field, MonoBehaviour component)
	{
		if (Settings.HasKey(attribute.Label))
		{ 
			var newValue = Settings.LoadSetting(attribute.Label, field.FieldType);
			field.SetValue(component, newValue);
		}
		else
		{
			Settings.SaveSetting(attribute.Label, field.GetValue(component));
		}
	}
}
