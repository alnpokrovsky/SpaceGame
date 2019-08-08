using UnityEngine;

public static class ContentBounds {
    static private Bounds? BoxAbs(GameObject rootGameObject) {

        if (rootGameObject.transform.childCount == 0) {
            return rootGameObject.GetComponent<Renderer>()?.bounds; 
        }
        
        bool hasBounds = false;
        Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);

        for (int i = 0; i < rootGameObject.transform.childCount; ++i) {
            Bounds? childBounds = BoxAbs(rootGameObject.transform.GetChild(i).gameObject);
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

    static public Bounds? Box(GameObject rootGameObject) {
        Bounds? bounds = BoxAbs(rootGameObject);
        if (!bounds.HasValue) return bounds;
        else return new Bounds(
            rootGameObject.transform.InverseTransformPoint(bounds.Value.center),
            rootGameObject.transform.InverseTransformVector(bounds.Value.size)
        );
    }
}