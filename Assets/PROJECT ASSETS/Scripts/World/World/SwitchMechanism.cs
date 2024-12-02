using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMechanism : MonoBehaviour
{
    private int speed;
    [SerializeField] private int MOVESPEED;
    public MovingPlatforms MP;

    public void switchSpeed()
    {
        if (MP.speed == 0)
        {
            MP.speed = MOVESPEED;
        }
        else
        {
            MP.speed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnDestroy()
    {
        switchSpeed();
    }
}