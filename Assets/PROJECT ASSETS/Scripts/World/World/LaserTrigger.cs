using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    private HammerController2D player;
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        player = Player.GetComponent<HammerController2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.isHolding = true;
            player.objectXID.isHolding = true;
            player.isBool = true;
            player.objectXID.isBool = true;
            StartCoroutine(TimeDelay());
        }
    }

     private IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(1);
        player.isHolding = false;
        player.objectXID.isHolding = false;
        player.isBool = false;
        player.objectXID.isBool = false;
    }
}
