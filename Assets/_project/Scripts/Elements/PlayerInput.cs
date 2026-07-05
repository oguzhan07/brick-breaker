using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float mousePosX;
    private Player player;
    private void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DragStarted();
        }
        if (Input.GetMouseButton(0))
        {
            Dragged();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DragStopped();
        } 
    }

    void DragStarted()
    {
        
    }

    void Dragged()
    {
        mousePosX = Input.mousePosition.x;
        var mousePosNormalized = mousePosX - Screen.width / 2;
        mousePosNormalized = mousePosNormalized * 4 / Screen.width;
        player.MovePlayer(mousePosNormalized);
    }

    void DragStopped()
    {
        
    }
}
