using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPortal : MonoBehaviour
{
    private BoxCollider2D BoxCollider2D;
    private Transform Transform;
    private Vector3 PositionPortal;
    private SpriteRenderer SpriteRenderer;

    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Transform = GetComponent<Transform>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if(ResPortal.numberPortal > 0)
        {
            SpriteRenderer.enabled = false;
            PositionPortal = Transform.position;
            Portal.instance.PosPortal(BoxCollider2D, PositionPortal);
        }
    }
}
