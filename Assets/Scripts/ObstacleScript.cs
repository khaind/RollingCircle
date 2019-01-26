using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleScript : MonoBehaviour {
    public float scaleMin = 0.5f;
    public float scaleMax = 1f;
    //public User usr;

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        float scale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(scale, scale);
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.localPosition.y < -3f)
        {
            StartCoroutine("Suicide");
        }
	}

    IEnumerator Suicide()
    {
        Destroy(gameObject);
        yield return null;
    }
}
