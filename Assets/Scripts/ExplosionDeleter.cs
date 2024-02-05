using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDeleter : MonoBehaviour
{
    public void CheckAndDestroyChildren()
    {
        // Get all child objects of the current GameObject
        Transform[] children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }

        // Check if there are more than 5 children
        if (children.Length > 5)
        {
            // Destroy all children except the last one
            for (int i = 0; i < children.Length - 1; i++)
            {
                Destroy(children[i].gameObject);
            }
        }
    }
}
