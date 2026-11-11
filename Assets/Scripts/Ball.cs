using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Paddle paddle;

    private bool hasStared = false;
    private Vector3 paddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStared)
        {
            //Lock the ball to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;
        
            // Wait to mouse press to launch
            if (Input.GetMouseButtonDown(0))
            {
                hasStared = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(6.5f, 21.5f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));


        if (hasStared)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
