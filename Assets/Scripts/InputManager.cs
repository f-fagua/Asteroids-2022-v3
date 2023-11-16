using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event OnKeyPressed OnShootKeyPressed;
    public static event OnKeyPressed OnForwardKeyPressed;
    public static event OnRotateKeyPressed OnRotateKeyPressed;


    [SerializeField]
    private KeyCode m_ShootKey = KeyCode.Space;
    
    [SerializeField]
    private KeyCode m_MoveFordwardKey = KeyCode.UpArrow;
    
    [SerializeField]
    private KeyCode m_RotateLeftKey = KeyCode.LeftArrow;

    [SerializeField]
    private KeyCode m_RotateRightKey = KeyCode.RightArrow;

    private void Update()
    {
        if (Input.GetKeyDown(m_ShootKey))
        {
            if (OnShootKeyPressed != null)
                OnShootKeyPressed();
        }
        if (Input.GetKey(m_MoveFordwardKey))
        {
            if (OnForwardKeyPressed != null)
                OnForwardKeyPressed();
        }
        if (Input.GetKey(m_RotateLeftKey))
        {
            if (OnRotateKeyPressed != null)
                OnRotateKeyPressed(-1);
        }
        if (Input.GetKey(m_RotateRightKey))
        {
            if (OnRotateKeyPressed != null)
                OnRotateKeyPressed(1);
        }
    }
}

public delegate void OnKeyPressed();
public delegate void OnRotateKeyPressed(int dir);