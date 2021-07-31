using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        if(isDragActive && (Input.GetMouseButtonDown(0)))
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
        if(obj.name == "Wall1")
        {
            Instantiate(WALL1, pos, transform.rotation);
        }
        else if(obj.name == "Wall2")
        {
            Instantiate(WALL2, pos, transform.rotation);
        }
        else if (obj.name == "Left1")
        {
            Instantiate(LEFT1, pos, transform.rotation);
        }
    }
}
