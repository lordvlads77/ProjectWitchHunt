using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableBackground : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 1.0f;
    [SerializeField]
    private bool scrollHorizontally = true;
    void Update()
    {
        Vector2 offset = GetComponent<Renderer>().material.mainTextureOffset;

        float scrollAmount = Time.deltaTime * scrollSpeed;

        if (scrollHorizontally)
        {
            offset.x += scrollAmount;
        }
        else
        {
            offset.y += scrollAmount;
        }

        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}