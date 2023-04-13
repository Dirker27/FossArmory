using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    private static int DEFAULT_MAX_CHILDREN = 10;
    public int maxChildren = 10;

    public List<GameObject> garbageChildren = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        if (maxChildren < 0)
        {
            maxChildren = DEFAULT_MAX_CHILDREN;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        int childCount = 0;
        foreach (Transform child in GetComponentsInChildren<Transform>()) {

            if (childCount > maxChildren) {
                GameObject.Destroy(child.gameObject);
            }

            childCount++;
        }
    }
}
