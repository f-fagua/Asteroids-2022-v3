using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private List<T> m_Objects;

    public ObjectPool(int size, GameObject prefab)
    {
        m_Objects = new List<T>();
        for (var i = 0; i < size; i++)
        {
            var gameObject = Object.Instantiate(prefab);
            var pooledObject = gameObject.GetComponent<T>();
            m_Objects.Add(pooledObject);
            gameObject.SetActive(false);
        }
    }

    public T GetObject()
    {
        foreach (var pooledObject in m_Objects)
        {
            if (!pooledObject.gameObject.activeSelf)
            {
                pooledObject.gameObject.SetActive(true);
                return pooledObject;
            }
        }

        return null;
    }
    
    public void ReturnObject(T pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }
}
