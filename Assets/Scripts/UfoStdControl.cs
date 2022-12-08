using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoStdControl : MonoBehaviour
{
    public float ySpeed, xSpeed;
    private Rigidbody2D rb;
    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.down * ySpeed;
            
        }
        Invoke("Disable", 10f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * ySpeed;
        
    }

    private void Update()
    {
        if (rb.transform.position.y < 0)
        {
            rb.velocity = Vector2.zero;
        }
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
