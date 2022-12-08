using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BreakInfinity;




public class BulletControl : MonoBehaviour
{
    
    public float bulletSpeed;
    private Rigidbody2D rb;
    


    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = Vector2.up * bulletSpeed;
        }
        Invoke("Disable", 2f);
    }

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
        
    }
    void Disable()
    {
        gameObject.SetActive(false);
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        
        switch (coll.gameObject.tag)
        {
            case "ufo1":                
                
                coll.gameObject.SetActive(false);
                gameObject.SetActive(false);                
                MoneyManager.data.bux += IncreasementAmount(3);
                
                break;

            case "Meteor1":
                coll.gameObject.SetActive(false);
                gameObject.SetActive(false);                
                MoneyManager.data.bux += IncreasementAmount(5);
                break;
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public BigDouble IncreasementAmount(BigDouble stdMultp)
    {
        BigDouble increasement = 1 + MoneyManager.Instance.BuxPerSecond() * stdMultp;
        return increasement;
    }



    


}
