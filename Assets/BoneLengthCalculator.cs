using UnityEngine;

public class BoneLengthCalculator : MonoBehaviour
{
    public Transform shoulder;
    public Transform elbow;
    public Transform hand;

    void Start()
    {
        float upperArmLength = Vector3.Distance(shoulder.position, elbow.position);
        float forearmLength = Vector3.Distance(elbow.position, hand.position);

        Debug.Log("Upper Arm Length: " + upperArmLength);
        Debug.Log("Forearm Length: " + forearmLength);
    }
}