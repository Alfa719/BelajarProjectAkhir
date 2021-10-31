using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
    public float timeBetweenWalk = 1f;
    // Set batas area
    public float maxRange = 5f, minRange = 5f;

    private Rigidbody2D rb;
    Vector2 movement;
    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeBetweenWalk)
        {
            Movement();
            //MoveArea();
        }
    }
    void Movement()
    {
        timer = 0f;
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        movement = new Vector2(horiz, vert).normalized;
        rb.velocity = movement * speed;
    }
    void MoveArea()
    {
        Vector2 pos = transform.position;
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y >= minRange)
        {
            movement = Vector2.down * 2.5f;
            //rb.velocity = movement;
            rb.MovePosition(pos + movement);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= maxRange)
        {
            movement = Vector2.up * 2.5f;
            //rb.velocity = movement;
            rb.MovePosition(pos + movement);
        }
    }
}
