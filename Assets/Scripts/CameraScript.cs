using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject player;

    Transform playerTranform;

    void Awake()
    {
        Debug.Assert(player != null);
        playerTranform = player.transform;
    }

    // Update is called once per frame
    void LateUpdate () {
        Vector3 playerPos = playerTranform.localPosition;
        transform.localPosition = new Vector3(playerPos.x, transform.localPosition.y, transform.localPosition.z);
	}
}
