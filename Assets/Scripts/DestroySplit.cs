using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySplit : MonoBehaviour
{
    public string targetTag;

    public GameObject splitAsteroidPrefab;

    // Check for collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided GameObject has the specified tag
        if (other.CompareTag(targetTag) && this.gameObject.GetComponent<Asteroid>().split == true)
        {
            explodeDestroy();
        }
        if (other.CompareTag(targetTag) && this.gameObject.GetComponent<Asteroid>().split == false)
        {
            // Destroy this GameObject
            split();
            explodeDestroy();
        }
    }


    void explodeDestroy()
    {
        if (this.gameObject.GetComponent<Explode>() != null)
        {
            this.gameObject.GetComponent<Explode>().explodeOnImpact();
        }
        Destroy(gameObject);
    }

    // Check if the GameObject doesn't have a Collider2D attached
    void OnValidate()
    {
        if (GetComponent<Collider2D>() == null)
        {
            Debug.LogWarning("GarbageCollector: No Collider2D attached to GameObject.");
        }
    }

    void split()
    {
        Debug.Log("split please");
        GameObject split1 = Instantiate(splitAsteroidPrefab, transform.position, Quaternion.identity);
        GameObject split2 = Instantiate(splitAsteroidPrefab, transform.position, Quaternion.identity);
        split1.GetComponent<Asteroid>().split = true;
        split2.GetComponent<Asteroid>().split = true;

        split1.transform.localScale *= 0.5f; // Half the size
        split2.transform.localScale *= 0.5f;
        split1.GetComponent<Asteroid>().move();
        split2.GetComponent<Asteroid>().move();
        // Set the parent of the new GameObjects to be the same as the current GameObject
        //split1.transform.SetParent(transform);
        //split2.transform.SetParent(transform);
    }
}
