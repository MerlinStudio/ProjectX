using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    public static Vector2 SavedPosition;
    void Start()
    {
        SavedPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "SaveZone") 
        {
            SavedPosition = transform.position;
        }
    }
}
