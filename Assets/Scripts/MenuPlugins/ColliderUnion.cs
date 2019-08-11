using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

static public class ColliderUnion
{
    // Add a menu item called "Double Mass" to a Rigidbody's context menu.
    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
    static void DoubleMass(MenuCommand command)
    {
        Rigidbody body = (Rigidbody)command.context;
        body.mass = body.mass * 2;
        Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
    }

    

    [MenuItem("MenuPlugins/BoxCollider/Fit to Children")]
    static void FitToChildren() {
        foreach (GameObject rootGameObject in Selection.gameObjects) {
    
            Bounds? boundsmaybe = ContentBounds.Box(rootGameObject);
            if (boundsmaybe.HasValue) {
                Bounds bounds = boundsmaybe.Value;
                BoxCollider collider = rootGameObject.GetComponent<BoxCollider>();
                if (collider == null) {
                    collider = rootGameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
                }
                collider.center = bounds.center;
                collider.size = bounds.size;
                collider.isTrigger = true;
            }
        }
    }
}

#endif