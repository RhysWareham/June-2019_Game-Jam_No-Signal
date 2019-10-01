using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;

    [SerializeField]
    private Rigidbody2D myRigidbody2D;
    private Vector2 vanVel;

    private bool isGrounded = true;

    void Update ()
    {
        vanVel = myRigidbody2D.velocity;

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            vanVel.y += moveSpeed * Time.deltaTime;
            isGrounded = false;
        }

        myRigidbody2D.velocity = vanVel;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0.0f;
        }
    }
}
