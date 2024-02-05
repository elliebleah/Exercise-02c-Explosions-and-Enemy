using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject explosionPrefab;
    public Transform explosionHolder;
    void Start()
    {
        explosionHolder = GameObject.Find("explosionHolder").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explodeOnImpact()
    {
        explosionHolder = GameObject.Find("explosionHolder").transform;
        GameObject explosionObj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionObj.transform.SetParent(explosionHolder);
        explosionHolder.gameObject.GetComponent<ExplosionDeleter>().CheckAndDestroyChildren();
        //DestroyImmediate(explosionPrefab, true);
    }
}
