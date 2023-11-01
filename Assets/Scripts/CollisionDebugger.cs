using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDebugger
{
    private const int k_CircleSmooth = 10;
    
    public static void DrawColliders<T> (T[] colliders) where T : CustomCollider
    {
        foreach (var collider in colliders)
            DrawCollider(collider);
    }

    private static void DrawCollider<T> (T collider) where T : CustomCollider
    {
        var center = collider.transform.position;
        var points = new Vector3[k_CircleSmooth];
        
        for (var i = 0; i < k_CircleSmooth; i++)
        {
            var x = center.x + collider.Radius * Mathf.Cos( Mathf.Deg2Rad * 360 * i/10f);
            var z = center.z + collider.Radius * Mathf.Sin(Mathf.Deg2Rad * 360 * i/10f);
            points[i] = new Vector3(x, center.y, z);
        }

        for (var i = 0; i < k_CircleSmooth; i++)
        {
            var j = i + 1;
            if (j >= k_CircleSmooth)
                j = 0;
            Debug.DrawLine(points[i], points[j], Color.red);
        }
    }
}
