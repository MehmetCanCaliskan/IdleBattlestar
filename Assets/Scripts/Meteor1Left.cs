using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor1Left : MonoBehaviour
{
    public float ySpeed, xSpeed;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.down * ySpeed;
            rb.velocity += Vector2.right * xSpeed;
        }
        Invoke("Disable", 9f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * ySpeed;
        rb.velocity += Vector2.right * xSpeed;
    }

    

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
