using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResPortal : MonoBehaviour
{
    public static ResPortal instance = null;
    public Text Text;

    public static int numberPortal;

    void Start()
    {
        numberPortal = 0;
        if (instance == null) { instance = this; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Portal")
        {
            numberPortal++;
            PrintNumberPortal();
        }
    }

    public void PrintNumberPortal()
    {
        Text.text = numberPortal.ToString();
    }
}
