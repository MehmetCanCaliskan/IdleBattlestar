using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    float randY;
    Vector2 SpawnLeftUp;
    Vector2 SpawnRightUp;
    //Vector2 SpawnMiddleUp;
    //Vector2 SpawnRightUp;
    public float spawnMeteorRate = 6f;
    public float spawnUfoRate = 20f;
    float nextSpawnMeteorL = 0.0f;
    float nextSpawnMeteorR = 3f;

    public int spawnEnemyAmount = 7;
    public int spawnEnemyAmountBonus = 20;
    public int amountUfo;

    void Start()
    {
        
    }

    
    void Update()
    {

        SpawnEnemiesRandom();
    }


    void SpawnEnemiesRandom()
    {
        if (Time.time > nextSpawnMeteorL)
        {
            for (int i = 0; i < Random.Range(1,7); i++)
            {
                
                Invoke("SpawnMeteorsFromLeft", 0.1f);
            }
            nextSpawnMeteorL = Time.time + spawnMeteorRate;
        }
        if (Time.time > nextSpawnMeteorR)
        {
            for (int i = 0; i < Random.Range(1, 7); i++)
            {

                Invoke("SpawnMeteorsFromRight", 0.1f);
            }
            nextSpawnMeteorR = Time.time + spawnMeteorRate;
        }
    }



    void SpawnMeteorsFromLeft()
    {
        GameObject obj = ObjectPooler.current.GetPooledMeteorL();
        randY = Random.Range(2f, 7f);
        if (obj == null) return;
        SpawnLeftUp = new Vector2(-4f, randY);
        obj.transform.position = SpawnLeftUp;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);        
    }

    void SpawnMeteorsFromRight()
    {
        GameObject obj = ObjectPooler.current.GetPooledMeteorR();
        randY = Random.Range(4f, 7f);
        if (obj == null) return;
        SpawnLeftUp = new Vector2(4f, randY);
        obj.transform.position = SpawnLeftUp;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
    }

}
