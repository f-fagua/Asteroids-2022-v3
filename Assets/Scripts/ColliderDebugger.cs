using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDebugger 
{
    private const int k_Smooth = 8;
    
    public static void DrawColliders<T>(T[] colliders) where T : CustomCollider
    {
        foreach (var collider in colliders)
        {
            DrawCollider(collider);
        }
    }

    private static void DrawCollider<T>(T collider) where T : CustomCollider
    {
        var center = collider.transform.position;
        var points = new Vector3[k_Smooth];
        
        for (var i = 0; i < k_Smooth; i++)
        {
            var angle = i * (360f/k_Smooth);
            var x = center.x + Mathf.Cos(Mathf.Deg2Rad * angle) * collider.Radius;
            var z = center.z + Mathf.Sin(Mathf.Deg2Rad * angle) * collider.Radius;
            var point = new Vector3(x, 0, z);
            points[i] = point;
        }

        for (var i = 0; i < k_Smooth; i++)
        {
            var j = i + 1;
            if (j >= k_Smooth)
                j = 0;

            var pointA = points[i];
            var pointB = points[j];
            
            Debug.DrawLine(pointA, pointB, Color.red);
        }
    }
}
