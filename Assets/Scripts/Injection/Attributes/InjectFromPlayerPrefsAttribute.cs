using UnityEngine;
using System.Collections;
using System;

[AttributeUsage(AttributeTargets.Field)]
public class InjectFromPlayerPrefsAttribute : System.Attribute {

	public string Label
	{
		get;
		set;
	}

	public InjectFromPlayerPrefsAttribute(string label)
	{
		this.Label = label;
	}


	
}
