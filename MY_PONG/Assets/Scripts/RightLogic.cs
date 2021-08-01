using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLogic : MonoBehaviour
{
    Ball ball;
    public bool Right1;
    public bool Right2;
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
            if (Right1)
                ball.RightMovement(1);
            else if (Right2)
                ball.RightMovement(2);

            Destroy(gameObject);
        }


    }
}
