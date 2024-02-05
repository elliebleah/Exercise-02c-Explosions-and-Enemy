using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2f;
    public float shift;

    public bool split = false;

    public bool notSpawned = false;

    public void Start()
    {
        if (notSpawned)
        {
            move();
        }
    }

    // Method to launch the bullet in a specified direction


    public void move()
    {
        // Convert degrees to radians
        //float radians = degrees * Mathf.Deg2Rad;

        // Calculate direction based on ship's rotation
        float minAngle = -90f - shift;  // 90 degrees clockwise from the forward direction
        float maxAngle = 90f - shift;   // 90 degrees counterclockwise from the forward direction

        // Generate a random angle within the specified range
        float randomAngle = Random.Range(minAngle, maxAngle);

        // Convert the random angle to a direction vector
        Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        // Apply velocity to the bullet
        GetComponent<Rigidbody2D>().velocity = randomDirection * speed;
    }
}
