using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class CopyHierarchyPath
{
    [MenuItem("GameObject/拷贝层级路径", false, 0)]
    static void CopyNodePath()
    {
        string nodePath = string.Empty;
        GetNodePath(Selection.activeGameObject.transform, ref nodePath);

        // 复制到剪切板
        TextEditor editor = new TextEditor();
        editor.text = nodePath;
        editor.SelectAll();
        editor.Copy();
    }

    [MenuItem("GameObject/拷贝UI层级路径", false, 0)]
    static void CopyNodePathToUIRoot()
    {
        string nodePath = string.Empty;
        GetNodePath(Selection.activeTransform, ref nodePath, "Canvas");
        // 复制到剪切板
        TextEditor editor = new TextEditor();
        nodePath = nodePath.Substring(nodePath.IndexOf('/') + 1);
        nodePath = nodePath.Substring(nodePath.IndexOf('/') + 1);   // 删两遍，把panel本身也删掉
        editor.text = nodePath;
        editor.SelectAll();
        editor.Copy();;
    }

    static void GetNodePath(Transform trans, ref string path, string endRootName = "")
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
        GetNodePath(trans.parent, ref path, endRootName);
    }
}
