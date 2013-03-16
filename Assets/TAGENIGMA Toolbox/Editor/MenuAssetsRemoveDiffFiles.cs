using System;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Remove C# backup and meta files created when diffing files
/// </summary>
[RegisterSymbol(Name = "AS_2GR")]
public class MenuAssetsRemoveDiffFiles : MonoBehaviour
{
    /// <summary>
    /// Add a menu item to remove diff files that can cause issues
    /// </summary>
    [MenuItem("Assets/Remove C# Bak and C# Bak Meta Files")]
    public static void MenuRemoveCS()
    {
        MenuRemove(new string[]
        {
            "*.cs.bak",
            "*.cs.bak.meta"
        });
    }

    /// <summary>
    /// Add a menu item to remove diff files that can cause issues
    /// </summary>
    [MenuItem("Assets/Remove JS Bak and JS Bak Meta Files")]
    public static void MenuRemoveJS()
    {
        MenuRemove(new string[]
        {
            "*.js.bak",
            "*.js.bak.meta"
        });
    }

    /// <summary>
    /// Add a menu item to remove diff files that can cause issues
    /// </summary>
    [MenuItem("Assets/Remove Java Bak and Java Bak Meta Files")]
    public static void MenuRemoveJava()
    {
        MenuRemove(new string[]
        {
            "*.java.bak",
            "*.java.bak.meta"
        });
    }

    public static void MenuRemove(string[] extensions)
    {
        try
        {
            DirectoryInfo projectDir = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (null == projectDir)
            {
                return;
            }
            foreach (DirectoryInfo subDir in projectDir.GetDirectories())
            {
                if (null == subDir)
                {
                    continue;
                }
                if (subDir.Name.ToUpper().Equals("ASSETS"))
                {
                    RemoveBakMeta(subDir, extensions);
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError(string.Format("Exception={0}", ex));
        }

        AssetDatabase.Refresh();
        Debug.Log(string.Format("{0} Processing is done", DateTime.Now));
    }

    /// <summary>
    /// Look for bak and meta bak files
    /// </summary>
    /// <param name="directory"></param>
    public static void RemoveBakMeta(DirectoryInfo directory, string[] extensions)
    {
        if (null == directory)
        {
            return;
        }
        foreach (string extension in extensions)
        {
            foreach (FileInfo file in directory.GetFiles(extension))
            {
                if (file.Exists)
                {
                    Debug.Log(string.Format("Removed {0}", file));
                    File.Delete(file.FullName);
                    continue;
                }
            }
        }
        foreach (DirectoryInfo subDir in directory.GetDirectories())
        {
            if (null == subDir)
            {
                continue;
            }
            if (subDir.Name.ToUpper().Equals(".SVN"))
            {
                continue;
            }
            //Debug.Log(string.Format("Directory: {0}", subDir));
            RemoveBakMeta(subDir, extensions);
        }
    }
}