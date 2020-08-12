using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameToolUtility
{
    [MenuItem("GameTool/Init boot scene")]
    public static void BootScene()
    {
        EditorSceneManager.OpenScene("Assets/Scene/Boot.unity");
    }
}
