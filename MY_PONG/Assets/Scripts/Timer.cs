using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float time;
    int seconds;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
       
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
        }
        else if(time <= 0)
        {
            //finish round
            //start new round
        }
    }
}
