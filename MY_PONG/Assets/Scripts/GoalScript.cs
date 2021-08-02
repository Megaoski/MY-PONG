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

    public bool Zone1;
    public bool Zone2;
    public bool Zone3;
    public bool Zone4;
    public static bool Zone1Touched = false;
    public static bool Zone2Touched = false;
    public static bool Zone3Touched = false;
    public static bool Zone4Touched = false;

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
            if(Zone3Touched)
            {
                score1 += 1;
            }

            if (Zone4Touched)
            {
                score1 += 1;
                
            }
            score1 += 1;
            Zone3Touched = false;
            Zone4Touched = false;
            Player1HasScored = false;
        }

        if (Player2HasScored)
        {
            if (Zone1Touched)
            {
                score2 += 1;
                
            }

            if (Zone2Touched)
            {
                score2 += 1;
                
            }
            
            score2 += 1;
            Zone1Touched = false;
            Zone2Touched = false;
            Player2HasScored = false;
        }

        Debug.Log("P1: " + score1 + " P2: " + score2);
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

            if(Porteria1)
            {
                Player2HasScored = true;
                Debug.Log("Player 2 Scored");
                ball.Reset();
            }

            if (Zone1)
            {
                Zone1Touched = true;
                Debug.Log("Player 2 Bonus Score");
                
            }

            if (Zone2)
            {
                Zone2Touched = true;
                Debug.Log("Player 2 Bonus Score");

            }

            if (Zone3)
            {
                Zone3Touched = true;
                Debug.Log("Player 1 Bonus Score");

            }

            if (Zone4)
            {
                Zone4Touched = true;
                Debug.Log("Player 1 Bonus Score");

            }
        }

        
    }


    
}
