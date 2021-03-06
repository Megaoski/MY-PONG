using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time;
    int seconds;
    Text text;
    public bool timerEnd;

    GameObject canvasObject;
    Transform phaseTrans;
    Text phase;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        timerEnd = false;

        canvasObject = GameObject.Find("Canvas");
        phaseTrans = canvasObject.transform.Find("PHASE");
        phase = phaseTrans.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {        
        time -= Time.deltaTime;
        seconds = (int)(time % 60);
        //time = (int)time;

        if (time >= 0)
        {            
            text.text = seconds.ToString();
            phase.text = "PUT THE CARDS!";
        }
        else if(time <= 0)
        {
            timerEnd = true;
            phase.text = "LAUNCH THE BALL!";
        }
    }
}
