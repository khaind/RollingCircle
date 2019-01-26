using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    public GameObject squarePrefab;
    public float minDis = 3;
    public float maxDis = 5;
    public int numOfSquare = 4;

    public void Generate(Vector3 spawnPos)
    {
        for (int i = 0; i < numOfSquare; i++)
        {
            spawnPos.x += Random.Range(minDis, maxDis);

            Instantiate(squarePrefab, spawnPos, Quaternion.identity);
        }
    }
}
