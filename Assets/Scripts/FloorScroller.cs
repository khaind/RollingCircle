using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScroller : MonoBehaviour {

    public GameObject otherFloor;
    public GameObject player;
    public GameObject obstaclePool;

    float floorLength;
    
    const int NUM_OF_CHILD = 5;

    public float minDis = 3.8f;    // min distance b/w square in a floor
    public float maxDis = 5.8f;    // max distance b/w square in a floor
    int numOfSquare;

    private void Awake()
    {
        Debug.Assert(player != null);

        numOfSquare = obstaclePool.GetComponent<ObstaclePooler>().amountToPool / 2;
    }

    // Use this for initialization
    void Start ()
    {
        floorLength = NUM_OF_CHILD * 5; // meter
        Vector3 spawnPos = new Vector3(transform.localPosition.x - floorLength / 2, -1f, 0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Start moving previous floor behind
        if (IsPlayerNearEndFloor())
        {
            otherFloor.transform.localPosition = transform.localPosition + new Vector3(25.12f, 0, 0f);

            Vector3 spawnPos = new Vector3(otherFloor.transform.localPosition.x - floorLength / 2, -1f, 0f);
            SetUpPoolObjects(numOfSquare, spawnPos);
        }
	}

    private void SetUpPoolObjects(int numOfObj, Vector3 spawnPos)
    {
        for (int i = 0; i < numOfObj; i++)
        {
            GameObject square = ObstaclePooler.SharedInstance.GetPooledObject();
            if (square != null)
            {
                spawnPos.x += UnityEngine.Random.Range(minDis, maxDis);
                square.transform.position = spawnPos;
                square.SetActive(true);

            }
        }
    }

    bool IsPlayerNearEndFloor()
    {
        return (player.transform.localPosition.x > transform.localPosition.x) &&
            transform.localPosition.x > otherFloor.transform.localPosition.x;
    }
}
