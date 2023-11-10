using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event OnKeyPressed OnShootKeyPressed;

    [SerializeField]
    private KeyCode m_ShootKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(m_ShootKey))
        {
            if (OnShootKeyPressed != null)
                OnShootKeyPressed();
        }
    }
}

public delegate void OnKeyPressed();