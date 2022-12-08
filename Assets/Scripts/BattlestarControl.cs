using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlestarControl : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Animator animator;
    public Transform firePoint;
    public GameObject bulletPrefab; 
    

    void Start()
    {
        Application.targetFrameRate = 60;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

    
    void Fire()
    {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) return;
        obj.transform.position = firePoint.position;
        obj.transform.rotation = firePoint.rotation;
        obj.SetActive(true);
        animator.SetBool("isShooting", true);
    }
    

}
