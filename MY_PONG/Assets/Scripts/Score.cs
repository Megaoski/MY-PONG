using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    GameObject canvasObject;
    Transform score1Tr;
    Text score1Text;
    Transform score2Tr;
    Text score2Text;

    Transform attackP1;
    Image atckP1;
    Transform attackP1TXTGO;
    Text atckP1txt;

    Transform attackP2;
    Image atckP2;
    Transform attackP2TXTGO;
    Text atckP2txt;

    public int Score1;
    public int Score2;

    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();

        canvasObject = GameObject.Find("Canvas");
        score1Tr = canvasObject.transform.Find("Score1");
        score1Text = score1Tr.GetComponent<Text>();
        score2Tr = canvasObject.transform.Find("Score2");
        score2Text = score2Tr.GetComponent<Text>();

        attackP1 = canvasObject.transform.Find("P1ATTACK");
        atckP1 = attackP1.GetComponent<Image>();
        attackP1TXTGO = attackP1.transform.Find("P1ATTACKTXT");
        atckP1txt = attackP1TXTGO.GetComponent<Text>();

        attackP2 = canvasObject.transform.Find("P2ATTACK");
        atckP2 = attackP2.GetComponent<Image>();
        attackP2TXTGO = attackP2.transform.Find("P2ATTACKTXT");
        atckP2txt = attackP2TXTGO.GetComponent<Text>();


        //Score1 = GoalScript.score1;
        //Score2 = GoalScript.score2;
    }

    // Update is called once per frame
    void Update()
    {

        if (ball.AttackerP1 == false)
        {
            atckP1txt.enabled = false;
            atckP1.enabled = false;

            atckP2txt.enabled = true;
            atckP2.enabled = true;

        }

        if (ball.AttackerP2 == false)
        {
            atckP1txt.enabled = true;
            atckP1.enabled = true;

            atckP2txt.enabled = false;
            atckP2.enabled = false;
        }

             


        Score1 = GoalScript.score1;
        Score2 = GoalScript.score2;

        score1Text.text = Score1.ToString();
        score2Text.text = Score2.ToString();

        //Debug.Log("" + Score1);
    }
}
