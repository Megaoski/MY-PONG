using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public static int score1;
    public static int score2;
    public bool Porteria1;
    public bool Porteria2;
    public static bool Player1HasScored = false;
    public static bool Player2HasScored = false;

    Ball ball;
    
    void Start()
    {
        score1 = 0;
        score2 = 0;

        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();//to call and reset the ball

    }
    void Update()
    {
        if (Player1HasScored)
        {
            score1 += 1;
            Player1HasScored = false;
        }

        if (Player2HasScored)
        {
            score2 += 1;
            Player2HasScored = false;
        }

        Debug.Log(score1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (Porteria2)
            {
                Player1HasScored = true;
                Debug.Log("Player 1 Scored");
                ball.Reset();
            }
            else
            {
                Player2HasScored = true;
                Debug.Log("Player 2 Scored");
                ball.Reset();
            }
           
        }

        
    }


    
}
