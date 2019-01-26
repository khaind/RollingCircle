using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScroller : MonoBehaviour {
    public GameObject other;
    public GameObject[] squares;

    ObstacleGenerator obstacleGenertor;

    GameObject player;
    float floorLength;
    const int NUM_OF_CHILD = 5;

    private void Awake()
    {
        player = GameObject.Find("Player");
        obstacleGenertor = GameObject.Find("ObstacleGenerator").GetComponent<ObstacleGenerator>();
        Debug.Assert(player != null);
    }

    // Use this for initialization
    void Start ()
    {
        floorLength = NUM_OF_CHILD * 5; // meter
        Vector3 spawnPos = new Vector3(transform.localPosition.x - floorLength / 2, -1f, 0f);
        obstacleGenertor.Generate(spawnPos);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Start moving previous floor behind
        if (IsPlayerNearEndFloor())
        {
            other.transform.localPosition = transform.localPosition + new Vector3(25.12f, 0, 0f);

            Vector3 spawnPos = new Vector3(other.transform.localPosition.x - floorLength / 2, -1f, 0f);
            obstacleGenertor.Generate(spawnPos);
        }
	}

    bool IsPlayerNearEndFloor()
    {
        return (player.transform.localPosition.x > transform.localPosition.x) &&
            transform.localPosition.x > other.transform.localPosition.x;
    }
}
