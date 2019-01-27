using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleScript : MonoBehaviour
{
    public float scaleMin = 0.6f;
    public float scaleMax = 1f;
    //public User usr;

    private Rigidbody2D rb;
    Camera mainCam;
    BoxCollider2D squareCollider;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        float scale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(scale, scale);
        mainCam = Camera.main;

        squareCollider = gameObject.GetComponentInChildren<BoxCollider2D>();

        player = GameObject.Find("Player");

    }

    private void OnEnable()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        float scale = Random.Range(scaleMin, scaleMax);
        transform.localScale = new Vector3(scale, scale);
    }


    // Update is called once per frame
    void Update()
    {

        if (transform.localPosition.x < player.transform.localPosition.x - 10f)
        {
            //Debug.Log("out of cam " + gameObject.name);
            StartCoroutine("Suicide");
        }
    }

    IEnumerator Suicide()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
        yield return null;
    }

    bool isVisibleFromCamera()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCam);
        if (GeometryUtility.TestPlanesAABB(planes, squareCollider.bounds))
            return true;
        else
            return false;
    }
}
