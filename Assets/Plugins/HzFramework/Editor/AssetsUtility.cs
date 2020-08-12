using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AssetsUtility
{
    [MenuItem("Assets/[Custom] Get Asset Type", priority = 2001)]
    public static void GetAssetType()
    {
        UnityEngine.Object obj = Selection.activeObject;
        if (obj == null)
        {
            Debug.Log("未选中任何对象");
            return;
        }
        Debug.Log($"{obj.name} type is {obj.GetType()}");
    }
}
