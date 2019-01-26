using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    Transform playerTranform;

    void Awake()
    {
        playerTranform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate () {
        Vector3 playerPos = playerTranform.localPosition;
        transform.localPosition = new Vector3(playerPos.x, transform.localPosition.y, transform.localPosition.z);
	}
}
