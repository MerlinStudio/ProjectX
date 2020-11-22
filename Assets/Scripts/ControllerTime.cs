using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using DG.Tweening;
using System;

public class ControllerTime : MonoBehaviour
{
    public static ControllerTime instance = null;

    public Button ChangeTimeB;

    public TilemapCollider2D OldCollider, NewCollider;

    [Space]
    public BoxCollider2D[] ObjectOldTime;
    public BoxCollider2D[] ObjectNewTime;

    private ScaleData[] scaleDatas = new ScaleData[2];

    public GameObject Mask;
    private Transform Transform;
    private SpriteRenderer SpriteRenderer;
    private Image Image;

    private bool stateTime;
    void Start()
    {
        if(instance == null) { instance = this; }

        scaleDatas[0].size = 0;
        scaleDatas[0].time = 0.6f;
        scaleDatas[1].size = 250;
        scaleDatas[1].time = 0.6f;

        OldCollider.enabled = false;
        Transform = Mask.GetComponent<Transform>();
        SpriteRenderer = Mask.GetComponent<SpriteRenderer>();
        Image = ChangeTimeB.gameObject.GetComponent<Image>();

        ChangeTimeB.onClick.AddListener(ChengeTime);
        stateTime = true;
        ChengeScane(false, true, 0.6f, 0);
    }

    public void ChengeTime()
    {
        if(stateTime) 
        {
            ChengeScane(true, false, 0, 1);
            stateTime = false;
        }    
        else 
        {
            ChengeScane(false, true, 0.6f, 0);
            stateTime = true;
        }          
    }   

    private void ChengeScane(bool oldObject,bool newObject,float color,int index)
    {
        Transform.DOScale(scaleDatas[index].size, scaleDatas[index].time);
        SpriteRenderer.DOColor(new Color(1, 1, 1, color), scaleDatas[index].time);

        OldCollider.enabled = oldObject;
        NewCollider.enabled = newObject;

        foreach (BoxCollider2D i in ObjectOldTime)
        {
            i.enabled = oldObject;
        }
        foreach (BoxCollider2D i in ObjectNewTime)
        {
            i.enabled = newObject;
        }
    }

    [Serializable]
    public struct ScaleData
    {
        public float size;
        public float time;
    }

    public void ChangeColorTimeButton(Color color)
    {
        Image.color = color;
    }

    public void InterTimeButton(bool a)
    {
        ChangeTimeB.interactable = a;
    }
}
