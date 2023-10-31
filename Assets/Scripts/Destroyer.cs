using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    
    SpaceShip ship;
    AsteroidController [] asteroids;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ship = FindObjectOfType<SpaceShip>();
        asteroids = FindObjectsOfType<AsteroidController>();

        if (ship != null)
        {
            for(int i = 0; i < asteroids.Length; i++)
            {
                AsteroidController asteroid = asteroids[i];
            
                 if (HasCollide(asteroid))
            
                {
                    Destroy(ship.gameObject);
                    GameManager.Lives -= 1;
                    Invoke("LoadScene", 2);
                }
            }
        }

        UpdateCollisions();
    }

    private void UpdateCollisions()
    {
        var colliders = FindObjectsOfType<CustomCollider>();

        CollisionDebugger.DrawColliders(colliders);
        /*
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int j = i+1; j < colliders.Length; j++)
            {
                var colliderA = colliders[i];
                var colliderB = colliders[j];

                if (colliderA != colliderB &&
                    Vector3.Distance(colliderA.transform.position, colliderB.transform.position) <
                    (colliderA.Radius + colliderB.Radius))
                {
                    if (colliderA.Type == ColliderType.Ship && colliderB.Type == ColliderType.Bullet ||
                        colliderA.Type == ColliderType.Bullet && colliderB.Type == ColliderType.Ship)
                        continue;
                    if (colliderA.Type == ColliderType.Asteroid && colliderB.Type == ColliderType.Asteroid)
                        continue;
                    
                    Debug.Log($"Collision between {colliderA.Type} and {colliderB.Type}");
                }
            }
        }
        */
    }

    private void LoadScene()

    {
        if (GameManager.Lives > 0)
            GameManager.LoadScene("Asteroids 2022 v2 main");
            
        else
            GameManager.LoadScene("Game Over");
    }


    private bool HasCollide(AsteroidController asteroid)
    {
        var shipRadius = ship.Radius;
       // var asteroidPosition = asteroids.transform.position;

        var collisionDistance = asteroid.Radius + shipRadius;

        var currentDistance = Vector3.Distance(asteroid.transform.position, ship.transform.position);

        return (currentDistance < collisionDistance);
       

    }
}
    