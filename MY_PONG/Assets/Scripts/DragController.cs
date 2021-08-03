using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DragController : MonoBehaviour
{
    public Draggable LastDragged => lastDragged;

    private bool isDragActive = false;
    private Vector2 screenPosition;
    private Vector3 worldPosition;
    private Draggable lastDragged;

    public GameObject WALL1;
    public GameObject WALL2;
    public GameObject LEFT1;
    public GameObject LEFT2;
    public GameObject RIGHT1;
    public GameObject RIGHT2;
    public GameObject WARP1;
    public GameObject WARP2;

    Ball ball;
    //private Vector3 newPosition;

    // Start is called before the first frame update
    void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("CONCEPT");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(ball.AttackerP1)
            {
                ball.AttackerP2 = true;
                ball.AttackerP1 = false;
            }
            else if(ball.AttackerP2)
            {
                ball.AttackerP1 = true;
                ball.AttackerP2 = false;
            }
        }

        if (isDragActive && (Input.GetMouseButtonDown(0)))
        {
            Drop();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else
        {
            return;
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if(isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if(hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if(draggable != null)
                {
                    lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        lastDragged.LastPosition = lastDragged.transform.position;
        UpdateDragStatus(true);
    }

    void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    void Drop()
    {
        UpdateDragStatus(false);
        //newPosition = lastDragged.transform.position;
        //checkear si la carata se esta usando en el campo correcto, sino no hacerla desaparecer
        //CheckCard(lastDragged.gameObject);
        //Destroy(lastDragged.gameObject);
    }

    void UpdateDragStatus(bool IsDragging)
    {
        isDragActive = lastDragged.IsDragging = IsDragging;

        if(IsDragging)
        {
            lastDragged.gameObject.layer = Layer.Dragging;
        }
        else
        {
            lastDragged.gameObject.layer = Layer.Default;
        }
    }

    public void CheckCard(GameObject obj, Vector3 pos)
    {
        if(obj.name == "Wall1" || obj.name == "Wall1.2")
        {
            Instantiate(WALL1, pos, transform.rotation);
        }
        else if(obj.name == "Wall2" || obj.name == "Wall2.2")
        {
            Instantiate(WALL2, pos, transform.rotation);
        }
        else if (obj.name == "Left1")
        {
            Instantiate(LEFT1, pos, transform.rotation);
        }
        else if (obj.name == "Left2")
        {
            Instantiate(LEFT2, pos, transform.rotation);
        }
        else if (obj.name == "Right1")
        {
            Instantiate(RIGHT1, pos, transform.rotation);
        }
        else if (obj.name == "Right2")
        {
            Instantiate(RIGHT2, pos, transform.rotation);
        }
        else if (obj.name == "Warp1")
        {
            Instantiate(WARP1, pos, transform.rotation);
        }
        else if (obj.name == "Warp2")
        {
            Instantiate(WARP2, pos, transform.rotation);
        }
    }
}
