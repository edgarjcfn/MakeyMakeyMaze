using UnityEngine;
using System.Collections;
using UnityEditor;

public class MazeMenu : EditorWindow {

	[MenuItem("5moff/ClearPlayerPrefs")]
	public static void ClearPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log("Player Prefs Deleted");
	}
}
