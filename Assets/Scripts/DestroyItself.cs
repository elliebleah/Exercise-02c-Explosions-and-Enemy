using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    // Start is called before the first frame update
    public void selfDestroy()
    {
        Destroy(gameObject);
    }
}
