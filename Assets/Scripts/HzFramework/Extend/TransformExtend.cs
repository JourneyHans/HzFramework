using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtend
{
    /// <summary>
    /// 查找子节点上的某个组件
    /// </summary>
    /// <typeparam name="T">想要的组件类型，类型必须继承自Component</typeparam>
    /// <param name='transform'>transform调用</param>
    /// <param name="name">子节点名称</param>
    public static T Find<T>(this Transform transform, string name) where T : Component
    {
        return transform.Find(name).GetComponent<T>();
    }

    /// <summary>
    /// 查找节点的根节点
    /// </summary>
    /// <param name="transform"></param>
    /// <returns></returns>
    public static Transform FindRoot(this Transform transform)
    {
        if (transform.parent == null)
        {
            return transform;
        }

        return FindRoot(transform.parent);
    }
}
