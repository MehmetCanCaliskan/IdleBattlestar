using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    Material material;
    Vector2 offset;

    public float xVelocity,yVelocity;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(xVelocity, yVelocity);
    }

    
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
