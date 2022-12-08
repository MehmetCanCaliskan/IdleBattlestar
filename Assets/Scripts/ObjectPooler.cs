using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler current;
    
    public  int pooledAmount;
    public int pooledAmountEnemy;
    public int pooledAmountUfo;
    public bool willGrow;

    private List<GameObject> pooledObjects;
    public GameObject pooledObject;

    private List<GameObject> pooledMeteorsL;
    public GameObject pooledMeteorL;

    private List<GameObject> pooledMeteorsR;
    public GameObject pooledMeteorR;

    private List<GameObject> pooledStdUfos;
    public GameObject pooledStdUfo;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        pooledMeteorsL = new List<GameObject>();
        pooledMeteorsR = new List<GameObject>();
        pooledStdUfos = new List<GameObject>();
        current = this;
        InstantiateAtTheStart();
    }

    
    void InstantiateAtTheStart()
    {
        // creating list for bullets
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        // creating list for meteors from Left
        for (int i = 0; i < pooledAmountEnemy; i++)
        {
            GameObject obj = Instantiate(pooledMeteorL);
            obj.SetActive(false);
            pooledMeteorsL.Add(obj);
        }
        // creating list for meteors from Right
        for (int i = 0; i < pooledAmountEnemy; i++)
        {
            GameObject obj = Instantiate(pooledMeteorR);
            obj.SetActive(false);
            pooledMeteorsR.Add(obj);
        }
        // creating list for stdUfos
        for (int i = 0; i < pooledAmountUfo; i++)
        {
            GameObject obj = Instantiate(pooledStdUfo);
            obj.SetActive(false);
            pooledStdUfos.Add(obj);
        }


    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj; 
        }
        return null;
    }

    public GameObject GetPooledMeteorR()
    {
        for (int i = 0; i < pooledMeteorsR.Count; i++)
        {
            if (!pooledMeteorsR[i].activeInHierarchy)
            {
                return pooledMeteorsR[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledMeteorR);
            pooledMeteorsR.Add(obj);
            return obj;
        }
        return null;
    }

    public GameObject GetPooledMeteorL()
    {
        for (int i = 0; i < pooledMeteorsL.Count; i++)
        {
            if (!pooledMeteorsL[i].activeInHierarchy)
            {
                return pooledMeteorsL[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledMeteorL);
            pooledMeteorsL.Add(obj);
            return obj;
        }
        return null;
    }

    public GameObject GetPooledStdUfos()
    {
        for (int i = 0; i < pooledStdUfos.Count; i++)
        {
            if (!pooledStdUfos[i].activeInHierarchy)
            {
                return pooledStdUfos[i];
            }
        }
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledStdUfo);
            pooledStdUfos.Add(obj);
            return obj;
        }
        return null;
    }
}
