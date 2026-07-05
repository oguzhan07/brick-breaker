using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public void RestartPlayer()
    {
        transform.position = new Vector3(0, transform.position.y, 0);
    }

    public void MovePlayer(float xPos)
    {
        xPos = Mathf.Clamp(xPos, -2f, 2f);
        transform.position = new Vector3(xPos, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            print("top");
        }
}
}
