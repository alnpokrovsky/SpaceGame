using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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

    static private Bounds? ContentBoundsAbs(GameObject rootGameObject) {

        if (rootGameObject.transform.childCount == 0) {
            return rootGameObject.GetComponent<Renderer>()?.bounds; 
        }
        
        bool hasBounds = false;
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

        for (int i = 0; i < rootGameObject.transform.childCount; ++i) {
            Bounds? childBounds = ContentBoundsAbs(rootGameObject.transform.GetChild(i).gameObject);
            if (childBounds.HasValue) {
                if (hasBounds) {
                    bounds.Encapsulate(childBounds.Value);
                } else {
                    bounds = childBounds.Value;
                    hasBounds = true;
                }
            }
        }

        return hasBounds ? bounds : (Bounds?)null;
    }

    static public Bounds? ContentBounds(GameObject rootGameObject) {
        Bounds? bounds = ContentBoundsAbs(rootGameObject);
        if (!bounds.HasValue) return bounds;
        else return new Bounds(
            rootGameObject.transform.InverseTransformPoint(bounds.Value.center),
            rootGameObject.transform.InverseTransformVector(bounds.Value.size)
        );
    }

    [MenuItem("MenuPlugins/BoxCollider/Fit to Children")]
    static void FitToChildren() {
        foreach (GameObject rootGameObject in Selection.gameObjects) {
    
            Bounds? boundsmaybe = ContentBounds(rootGameObject);
            if (boundsmaybe.HasValue) {
                Bounds bounds = boundsmaybe.Value;
                //  BoxCollider collider = (BoxCollider)rootGameObject.GetComponent<Collider>();
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
