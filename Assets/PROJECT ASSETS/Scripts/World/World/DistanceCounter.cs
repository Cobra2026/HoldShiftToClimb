using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private Transform body;

    [SerializeField] private TextMeshProUGUI distanceText;

    private float distance;

    private void Update()
    {
        // distance = (body.transform.position - transform.position).magnitude;

        // distanceText.text = "Distance: " + distance.ToString("F1") + "meters";
        distance = body.transform.position.y + 27.5f;
        int distanceRounded = (int) distance;

        distanceText.text = "Height: " + distance.ToString("F1") + "ft.";
    }
}
