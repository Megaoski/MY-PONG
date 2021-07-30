﻿using System.Collections;
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

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
        dragController = FindObjectOfType<DragController>();
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
            if(other.CompareTag("DropValid"))
            {
                movementDestination = other.transform.position;
            }
            else if(other.CompareTag("DropInvalid"))
            {
                movementDestination = LastPosition;
            }
      }

}