using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class DOTScaling : MonoBehaviour
{
    [SerializeField] private ParticleSystem Particle;

    [SerializeField] private ScaleData[] scaleDatas;
    [SerializeField] private BoxCollider2D BoxCollider2D;

    private int index;
    void Start()
    {
        BoxCollider2D.enabled = false;
        index = 1;
        Scaling();
    }

    private void Scaling()
    {
        if(index >= scaleDatas.Length) { index = 0; }

        transform.DOScale(scaleDatas[index].size, scaleDatas[index].time).OnComplete(()=>Scaling()).SetDelay(scaleDatas[index].delay);
        if (index == 0) 
        { 
            BoxCollider2D.enabled = false;
        }
        if (index == 1) 
        { 
            BoxCollider2D.enabled = true;
            if(Particle != null) { Particle.Play(true);}           
        }
        index++;
    }

    [Serializable]
    public struct ScaleData
    {
        public float size;
        public float time;
        public float delay;
    }
}
