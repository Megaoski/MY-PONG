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

    public int Score1;
    public int Score2;
    // Start is called before the first frame update
    void Start()
    {
        canvasObject = GameObject.Find("Canvas");
        score1Tr = canvasObject.transform.Find("Score1");
        score1Text = score1Tr.GetComponent<Text>();
        score2Tr = canvasObject.transform.Find("Score2");
        score2Text = score2Tr.GetComponent<Text>();

        //Score1 = GoalScript.score1;
        //Score2 = GoalScript.score2;
    }

    // Update is called once per frame
    void Update()
    {
        Score1 = GoalScript.score1;
        Score2 = GoalScript.score2;

        score1Text.text = Score1.ToString();
        score2Text.text = Score2.ToString();

        //Debug.Log("" + Score1);
    }
}
