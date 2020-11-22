using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class DOTColor : MonoBehaviour
{
    [SerializeField] private ChangeData[] changeData;
    private SpriteRenderer SpriteRenderer;
    private int index;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    private void ChangeColor()
    {
        if (index >= changeData.Length) { index = 0; }

        SpriteRenderer.DOColor(changeData[index].Color, changeData[index].time).OnComplete(() => ChangeColor()).SetDelay(changeData[index].delay);
        index++;
    }

    [Serializable]
    public struct ChangeData
    {
        public Color Color;
        public float time;
        public float delay;
    }
}
