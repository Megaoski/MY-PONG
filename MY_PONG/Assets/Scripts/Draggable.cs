using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;

    private Collider2D Collider;

    private DragController dragController;

    public Vector3 LastPosition;

    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDestination;

    GameObject canvasObject;
    Transform timerTrans;
    Timer timer;

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
        dragController = FindObjectOfType<DragController>();

        canvasObject = GameObject.Find("Canvas");
        timerTrans = canvasObject.transform.Find("Timer");
        timer = timerTrans.GetComponent<Timer>();
    }

    void FixedUpdate()
    {
        if(movementDestination.HasValue)
        {
            if(IsDragging)
            {
                movementDestination = null;
                return;
            }

            if(transform.position == movementDestination)
            {
                gameObject.layer = Layer.Default;
                movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Draggable collidedDraggable = other.GetComponent<Draggable>();

        if(collidedDraggable != null && dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(Collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        if (timer.timerEnd == false)
        {
            if (other.CompareTag("Player1Valid") && dragController.LastDragged.gameObject.CompareTag("Player1Valid"))//if card can be droped on the space:
            {
                movementDestination = other.transform.position;//middle position of the space
                dragController.CheckCard(dragController.LastDragged.gameObject, movementDestination.Value);//we summon the card
                Destroy(gameObject);//lastly we destroy the used card
            }
            else if (other.CompareTag("Player2Valid") && dragController.LastDragged.gameObject.CompareTag("Player2Valid"))
            {
                movementDestination = other.transform.position;//middle position of the space
                dragController.CheckCard(dragController.LastDragged.gameObject, movementDestination.Value);//we summon the card
                Destroy(gameObject);//lastly we destroy teh used card
            }
        }
    }

}
