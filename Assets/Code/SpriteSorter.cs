using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public bool isStatic = false;
    public float offset = 0;
    public float mainOffset = 20f;
    
    private int sortingOrderBase = 0;
    private Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y + offset + mainOffset);
        
        if(isStatic)
            Destroy(this);
    }
}
