using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Persistent Data Path: \t\t" + PathUtil.persistentDataPath);
        Debug.Log("Assets Path: \t\t" + Application.dataPath);
        Debug.Log("Resources Path: \t\t" + PathUtil.resourcePath);
        Debug.Log("Streaming Assets Path: \t\t" + PathUtil.streamingAssetsPath);
        Debug.Log("Application.temporaryCachePath: \t\t" + Application.temporaryCachePath);
    }
}
