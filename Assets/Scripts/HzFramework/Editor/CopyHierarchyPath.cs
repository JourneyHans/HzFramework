﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public static class CopyHierarchyPath
{
    private static string _nodeStart = string.Empty;
    private static string _nodeEnd = string.Empty;

    [MenuItem("GameObject/Tool/拷贝层级路径", false, 0)]
    static void CopyNodePath()
    {
        Transform[] t = Selection.transforms;
        string nodePath = string.Empty;
        GetNodePath(Selection.activeGameObject.transform, ref nodePath);

        // 复制到剪切板
        TextEditor editor = new TextEditor();
        editor.content = new GUIContent(nodePath);
        editor.SelectAll();
        editor.Copy();
    }

    static void GetNodePath(Transform trans, ref string path)
    {
        if (path == "")
        {
            path = trans.name;
        }
        else
        {
            path = trans.name + "/" + path;
        }

        if (trans.parent != null)
        {
            GetNodePath(trans.parent, ref path);
        }
    }
}
