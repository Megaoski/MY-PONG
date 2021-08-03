using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public  float speed;
    public Rigidbody2D rb;

     Vector3 startPosition;
     Vector3 point1;
     Vector3 point2;
     Vector3 point3;
     Vector3 point4;
     Vector3 point5;
     Vector3 point6;

    public bool AttackerP1 = true;
    public bool AttackerP2 = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        //Launch();
        point1 = GameObject.Find("P1").transform.position;
        point2 = GameObject.Find("P2").transform.position;
        point3 = GameObject.Find("P3").transform.position;
        point4 = GameObject.Find("P4").transform.position;
        point5 = GameObject.Find("P5").transform.position;
        point6 = GameObject.Find("P6").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("1") && AttackerP1 && !AttackerP2)
        {
            gameObject.transform.position = point1;
            Launch(1);
            AttackerP1 = false;
            AttackerP2 = true;
        }

        if(Input.GetKey("2") && AttackerP1 && !AttackerP2)
        {
            gameObject.transform.position = point2;
            Launch(2);
            AttackerP1 = false;
            AttackerP2 = true;
        }

        if (Input.GetKey("3") && AttackerP1 && !AttackerP2)
        {
            gameObject.transform.position = point3;
            Launch(3);
            AttackerP1 = false;
            AttackerP2 = true;
        }

        if (Input.GetKey("4") && !AttackerP1 && AttackerP2)
        {
            gameObject.transform.position = point4;
            Launch(4);
            AttackerP2 = false;
            AttackerP1 = true;
        }

        if (Input.GetKey("5") && !AttackerP1 && AttackerP2)
        {
            gameObject.transform.position = point5;
            Launch(5);
            AttackerP2 = false;
            AttackerP1 = true;
        }

        if (Input.GetKey("6") && !AttackerP1 && AttackerP2)
        {
            gameObject.transform.position = point6;
            Launch(6);
            AttackerP2 = false;
            AttackerP1 = true;
        }
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        //Launch();
    }
    private void Launch(int point)
    {
        //float x = Random.Range(0, 2) == 0 ? -1 : 1;
        //float y = Random.Range(0, 2) == 0 ? -1 : 1;
        GoalScript.Zone1Touched = false;
        GoalScript.Zone2Touched = false;
        GoalScript.Zone3Touched = false;
        GoalScript.Zone4Touched = false;

        if (point == 1)
        {
            float x = 1;
            float y = 0;

            rb.velocity = new Vector2(speed * x, speed * y);
        }
        else if(point == 2)
        {
             float x = 1;
             float y = 0;

             rb.velocity = new Vector2(speed * x, speed * y);
         }
        else if (point == 3)
        {
            float x = 1;
            float y = 0;

            rb.velocity = new Vector2(speed * x, speed * y);
        }
        else if (point == 4)
        {
            float x = -1;
            float y = 0;

            rb.velocity = new Vector2(speed * x, speed * y);
        }
        else if (point == 5)
        {
            float x = -1;
            float y = 0;

            rb.velocity = new Vector2(speed * x, speed * y);
        }
        else if (point == 6)
        {
            float x = -1;
            float y = 0;

            rb.velocity = new Vector2(speed * x, speed * y);
        }


    }

    public void LeftMovement(int num)
    {
        if (num == 1)
        {
            float x = 1;
            float y = 1;
            Vector3 newDirection = new Vector3(x, y, 0);
            Vector3 newVelocity = newDirection.normalized * speed;
            rb.velocity = newVelocity;
            //rb.velocity = new Vector2(speed * x, speed * y);
        }
        else if (num == 2)
        {
            float x = -1;
            float y = -1;
            Vector3 newDirection = new Vector3(x, y, 0);
            Vector3 newVelocity = newDirection.normalized * speed;
            rb.velocity = newVelocity;
            //rb.velocity = new Vector2(speed * x, speed * y);
        }
    }

    public void RightMovement(int num)
    {
        if (num == 1)
        {
            float x = 1;
            float y = -1;
            Vector3 newDirection = new Vector3(x, y, 0);
            Vector3 newVelocity = newDirection.normalized * speed;
            rb.velocity = newVelocity;
            
            //rb.velocity = new Vector2(speed * x, speed * y);
        }
        else if (num == 2)
        {
            float x = -1;
            float y = 1;
            Vector3 newDirection = new Vector3(x, y, 0);
            Vector3 newVelocity = newDirection.normalized * speed;
            rb.velocity = newVelocity;
            //rb.velocity = new Vector2(speed * x, speed * y);
        }
    }

    public void Warping(int num)
    {
        if (num == 1)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 8, gameObject.transform.position.y, gameObject.transform.position.z); 
        }
        else if (num == 2)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 8, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }

}
