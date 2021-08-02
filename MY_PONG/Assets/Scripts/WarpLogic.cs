using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpLogic : MonoBehaviour
{

    Ball ball;
    public bool Warp1;
    public bool Warp2;
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
            if (Warp1)
                ball.Warping(1);
            else if (Warp2)
                ball.Warping(2);

            Destroy(gameObject);
        }


    }
}
