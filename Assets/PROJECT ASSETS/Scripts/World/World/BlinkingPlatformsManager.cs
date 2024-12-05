using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatformsManager : MonoBehaviour
{
    public static BlinkingPlatformsManager instance;
    [SerializeField] private List<BlinkingPlatforms> blinkingPlatforms = new List<BlinkingPlatforms>();
    [SerializeField] private float seconds;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddPlatform(BlinkingPlatforms platform)
    {
        if (!blinkingPlatforms.Contains(platform))
        {
            blinkingPlatforms.Add(platform);
        }
    }

    public void DeactivatePlatform(BlinkingPlatforms platform, float duration)
    {
        // if (blinkingPlatforms.Contains(platform))
        // {
            StartCoroutine(DeactivateForSeconds(platform, duration));
        // }
    }

    private IEnumerator DeactivateForSeconds(BlinkingPlatforms platform, float seconds)
    {
        yield return new WaitForSeconds(2);
        platform.gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        platform.gameObject.SetActive(true);
    }
}
