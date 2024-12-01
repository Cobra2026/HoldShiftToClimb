using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatforms : MonoBehaviour
{
    public bool isFalling, isBlinking = false;
    public GameObject BlinkingP;
    [SerializeField] private int ID;

    void Start()
    {
        if (BlinkingP == null)
        {
            Debug.LogError("BlinkingP is not assigned!");
            return;
        }

        if (ID == 0 || ID == 1)
        {
            float delay = ID == 0 ? 0f : 2f;
            InvokeRepeating("ToggleBlinking", delay, 2f);
        }
    }
    void Update()
    {
        if(isFalling && ID == 3)
        {
            BlinkingPlatformsManager.instance.isFalling = true;
        }
    }

        private void ToggleBlinking()
    {
        BlinkingP.SetActive(!BlinkingP.activeSelf);
    }
}
