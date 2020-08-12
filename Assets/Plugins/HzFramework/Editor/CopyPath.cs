using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CopyPath
{
    [MenuItem("Assets/[Custom] Copy Project Path", priority = 2000)]
    public static void GetObjectPath()
    {
        Object[] arr = Selection.GetFiltered(typeof(Object), SelectionMode.TopLevel);
        GUIUtility.systemCopyBuffer = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/" +
                                      AssetDatabase.GetAssetPath(arr[0]);
    }
}
