using UnityEngine;

/// <summary>
/// 路径工具类
/// </summary>
public class PathUtil
{
    /// <summary>
    /// 获取Resource路径
    /// </summary>
    public static string resourcePath
    {
        get
        {
            return Application.dataPath + "/Resources/";
        }
    }

    /// <summary>
    /// 获取数据存放目录（persistentDataPath）
    /// </summary>
    public static string persistentDataPath
    {
        get
        {
#if UNITY_ANDROID || UNITY_IOS
            return Application.persistentDataPath + "/";
#elif UNITY_EDITOR_OSX
            int i = Application.dataPath.LastIndexOf('/');
            return Application.dataPath.Substring(0, i + 1) + "/";
#else
            return Application.persistentDataPath + "/";
#endif
        }
    }

    /// <summary>
    /// 获取streamingassets路径
    /// </summary>
    public static string streamingAssetsPath
    {
        get
        {
#if UNITY_EDITOR && !UNITY_EDITOR_OSX
            return "file:///" + Application.streamingAssetsPath + "/";
#elif UNITY_IOS
            return "file://" + Application.streamingAssetsPath + "/";
#elif UNITY_ANDROID
            return Application.streamingAssetsPath + "/";
#else
            return "";
#endif
        }
    }
}
