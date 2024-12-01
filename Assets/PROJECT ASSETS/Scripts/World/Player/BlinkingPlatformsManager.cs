using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingPlatformsManager : MonoBehaviour
{
    public static BlinkingPlatformsManager instance;
    [SerializeField] private GameObject BlinkingP;
    public bool isFalling = false;
    public bool isBlinking = false;
    [SerializeField] private int ID;

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
        if(isFalling && ID == 3 && !isBlinking)
        {
            StartCoroutine (FallDelay());
        }
    }


    private IEnumerator FallDelay()
    {
        isBlinking = true;
        yield return new WaitForSeconds(2);
        BlinkingP.SetActive(false);
        yield return new WaitForSeconds(2);
        BlinkingP.SetActive(true);
        isBlinking = false;
        isFalling = false;
    }

    // private void OnTriggerStay2D(Collider2D collision)
    // {
    //     if(collision.CompareTag("Player"))
    //     {
    //         HammerController2D playerScript = collision.GetComponent<HammerController2D>();
    //         if (playerScript != null && !playerScript.isHolding)
    //         {
    //             isFalling = true;
    //             Debug.Log("YOU ARE FALLING!!!!!");
    //         }
    //     }
    // }
}