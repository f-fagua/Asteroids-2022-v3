using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField]
    private KeyCode m_KeyMoveForward;

    private MovementController m_MovementController;

    [SerializeField]
    private KeyCode m_KeyMoveLeft;

    [SerializeField]
    private KeyCode m_KeyMoveRight;

    [SerializeField]
    private float m_rotationSpeed;

    private Transform _currentPos;
    public GameObject bulletPrefab;
    public float bulletSpeed = 100.0f;
    private float m_SpeedIncrement = 1.0f;

    [SerializeField]
    public float m_Radius;

    // Start is called before the first frame update
    void Start()
    {
        // Get a reference to the Transform component that represents the current position of the space ship atte: Chat GPT
        _currentPos = transform;

       // m_MovementController = this.gameObject.GetComponent<MovementController>();
        m_MovementController = GetComponent<MovementController>();

        InputManager.OnShootKeyPressed += Shoot;
        InputManager.OnForwardKeyPressed += MoveForward;
        InputManager.OnRotateKeyPressed += Rotate;
    }

    private void OnDestroy()
    {
        InputManager.OnShootKeyPressed -= Shoot;
        InputManager.OnForwardKeyPressed -= MoveForward;
        InputManager.OnRotateKeyPressed -= Rotate;
    }

    private void MoveForward()
    {
        m_MovementController.speed += m_SpeedIncrement;
    }

    private void Rotate(int dir)
    {
        Vector3 eulerAngles = new Vector3(0, dir, 0);
        float rotationSpeed = m_rotationSpeed * Time.deltaTime;
        transform.Rotate(eulerAngles * rotationSpeed);
    }

    public float Radius  // Property
    {
        set => m_Radius = value;
        get => m_Radius;
    }

    public void Shoot()
   {
       Instantiate(bulletPrefab, _currentPos.position, _currentPos.rotation);
   }
}
