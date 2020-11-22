using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLift : MonoBehaviour
{
    [SerializeField] private GameObject Lift, Wheel1, Wheel2;

    private DOTMoving moveLift;
    private DOTRotation rotationWheel1, rotationWheel2;

    void Start()
    {
        moveLift = Lift.GetComponent<DOTMoving>();
        rotationWheel1 = Wheel1.GetComponent<DOTRotation>();
        rotationWheel2 = Wheel2.GetComponent<DOTRotation>();

        moveLift.enabled = false;
        rotationWheel1.enabled = false;
        rotationWheel2.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            moveLift.enabled = true;
            rotationWheel1.enabled = true;
            rotationWheel2.enabled = true;
        }
    }
}
