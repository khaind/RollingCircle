using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour {
    public static ObstaclePooler SharedInstance;

    public GameObject player;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool = 6;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.GetComponent<ObstacleScript>().player = player;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        // Return first non-nulll pool object
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
            else
                continue;
        }
        //3   
        return null;
    }
}
