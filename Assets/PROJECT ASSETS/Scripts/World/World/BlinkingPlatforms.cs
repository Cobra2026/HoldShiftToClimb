using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatforms : MonoBehaviour
{
    public bool isFalling, isBlinking = false;
    public GameObject BlinkingP;
    [SerializeField] PlatformType platformType;

    private void Start()
    {
        if (BlinkingP == null)
        {
            Debug.LogError("BlinkingP is not assigned!");
            return;
        }

        if (platformType == PlatformType.Blinking1 || platformType == PlatformType.Blinking2)
        {
            float delay = platformType == 0 ? 0f : 2f;
            InvokeRepeating("ToggleBlinking", delay, 2f);
        }

        // BlinkingPlatformsManager.instance.AddPlatform(this);
    }

    private void ToggleBlinking()
    {
        BlinkingP.SetActive(!BlinkingP.activeSelf);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HammerController2D playerScript = collision.GetComponent<HammerController2D>();
            if (playerScript != null && !playerScript.isHolding && platformType == PlatformType.Falling)
            {
                Debug.Log("Deactivating platform for 5 seconds.");
                BlinkingPlatformsManager.instance.DeactivatePlatform(this, 5f);
            }
        }
    }

    public enum PlatformType
{
    Blinking1 = 0,
    Blinking2 = 1,
    Regular = 2,
    Falling = 3
}
}
