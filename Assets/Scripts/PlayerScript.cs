#define AUTO_MOVE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce = 10f;
    public float moveSpeed = 2f;
    public User usr;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        usr.name = "Khai Nguyen";
        usr.score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space pressed");
            
            if (transform.localPosition.y > -2.4f)
                return;

            Vector2 velocity = rb.velocity;
            velocity.y = jumpForce;
            rb.velocity = velocity;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
#if AUTO_MOVE
        var translation = moveSpeed;
#else
        var translation = Input.GetAxis("Horizontal") * moveSpeed;
#endif
        Vector2 velocity = rb.velocity;
        velocity.x = translation;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("ScoreZone"))
        {
            //Debug.Log("New score = " + usr.score);
            usr.score += 10;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collide with " + collision.gameObject.name);
        if (collision.gameObject.name.Contains("Square"))
        {
            //Debug.Log("User killed with score = " + usr.score);
            SceneManager.LoadScene("GameOver");
        }
    }
}
