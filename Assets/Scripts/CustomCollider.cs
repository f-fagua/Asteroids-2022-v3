using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCollider : MonoBehaviour
{
    [SerializeField] 
    private ColliderType m_Type; 
    
    [SerializeField]
    private float m_Radius;
    
    public float Radius
    {
        get => m_Radius;
        set => m_Radius = value;
    }

    public ColliderType Type
    {
        get => m_Type;
    }
}

public enum ColliderType 
{
    Ship,
    Asteroid,
    Bullet
}
