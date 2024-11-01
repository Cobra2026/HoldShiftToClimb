using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMechanism : MonoBehaviour
{
    public int speed;
    public MovingPlatforms MP;

    public void switchSpeed()
    {
        if (MP.speed == 0)
        {
        MP.speed = 7;
        }
        else
        {
        MP.speed = 0;
        }
    }
}