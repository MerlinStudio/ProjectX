using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonTime : MonoBehaviour
{
    public static ChangeButtonTime instance = null;

    [SerializeField] private bool Damage;
    [SerializeField] private bool Block;

    void Start()
    {
        if(instance == null) { instance = this; }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && Damage) { ControllerTime.instance.ChangeColorTimeButton(new Color(1, 0, 0, 0.5f)); }
        if (collision.tag == "Player" && Block) { ControllerTime.instance.InterTimeButton(false); }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Damage) { ControllerTime.instance.ChangeColorTimeButton(new Color(1, 1, 1, 0.5f)); }
        if (collision.tag == "Player" && Block) { ControllerTime.instance.InterTimeButton(true); }
    }
}
