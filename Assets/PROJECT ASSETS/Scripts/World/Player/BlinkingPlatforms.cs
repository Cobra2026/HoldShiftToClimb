using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject BlinkingP;
    private bool isBlinking = true;

    void Start()
    {
        InvokeRepeating("ToggleBlinking", 0f, 1f);
    }

    private void ToggleBlinking()
    {
        if (isBlinking)
        {
            BlinkingP.SetActive(false);
        }
        else
        {
            BlinkingP.SetActive(true);
        }

        isBlinking = !isBlinking;
    }
}