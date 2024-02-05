using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class WaveEnemy : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float speed = 5f;
    public float amplitude = 1f;
    public float frequency = 1f;

    private float nextFireTime;
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }

        // Horizontal movement
        float horizontalMovement = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.Translate(Vector3.right * speed * Time.deltaTime * Mathf.Sign(horizontalMovement));

        // Sinusoidal wave movement along the y-axis
        float newY = startY + Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void Shoot()
    {
        // Perform raycast towards the player
        float shipRotation = transform.eulerAngles.z + 90f;
        float bulletRotation = shipRotation; 

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bulletPrefab.GetComponent<Bullet>().Launch(bulletRotation);

    }
}
