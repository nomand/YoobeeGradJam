using System;
using UnityEngine;
 
public static class UnityExtensions
{
    ///<summary>Applies an action to every gameobject in children</summary>
    ///<example><code>
    ///someObject.RunOnChildren(child => child.layer = LayerMask.NameToLayer("UI"));
    ///</code></example>
    public static void RunOnChildren(this GameObject go, Action<GameObject> action)
    {
        if (go == null) return;
        foreach (var trans in go.GetComponentsInChildren<Transform>(true))
        {
            action(trans.gameObject);
        }
    }
}