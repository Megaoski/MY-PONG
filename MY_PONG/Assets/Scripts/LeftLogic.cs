using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLogic : MonoBehaviour
{
    Ball ball;
    public bool Left1;
    public bool Left2;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();//to call and reset the ball
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if(Left1)
                ball.LeftMovement(1);
            else if(Left2)
                ball.LeftMovement(2);

            Destroy(gameObject);
        }


    }
}
