using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    private void FixedUpdate()
    {
        transform.position += direction.normalized * (speed * Time.fixedDeltaTime);
    }

    public void StartBall(Vector3 dir)
    {
        direction = dir;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Bounce(other.contacts[0].normal);
        }

        if (other.gameObject.CompareTag("Brick"))
        {
            Bounce(other.contacts[0].normal);
            other.gameObject.GetComponent<Brick>().GetHit();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Bounce(other.contacts[0].normal);
        }
    }

    void Bounce(Vector3 n)
    {
        direction = Vector3.Reflect(direction, n);
    }
}
