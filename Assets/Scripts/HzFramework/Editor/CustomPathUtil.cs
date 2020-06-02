using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class CustomPathUtil
{
    [MenuItem("Assets/拷贝全路径", priority = 1000)]
    public static void CopyFullPath()
    {
        Object[] objs = Selection.GetFiltered(typeof(Object), SelectionMode.TopLevel);
        GUIUtility.systemCopyBuffer = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/" +
                                      AssetDatabase.GetAssetPath(objs[0]);
    }

    [MenuItem("GameObject/拷贝层级路径", priority = -1)]
    public static void CopyNodePath()
    {
        string nodePath = string.Empty;
        if (Selection.activeGameObject == null)
        {
            Debug.Log("未选中任何目标");
            return;
        }
        _GetNodePath(Selection.activeGameObject.transform, ref nodePath);

        // 复制到剪切板
        TextEditor editor = new TextEditor();
        editor.text = nodePath;
        editor.SelectAll();
        editor.Copy();
    }

    private static void _GetNodePath(Transform trans, ref string path, string endRootName = "")
    {
        if (trans == null)
        {
            return;
        }

        if (trans.name == endRootName)
        {
            return;
        }

        if (path == "")
        {
            path = trans.name;
        }
        else
        {
            path = trans.name + "/" + path;
        }
        _GetNodePath(trans.parent, ref path, endRootName);
    }
}
