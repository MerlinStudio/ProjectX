using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PrefabPortal : MonoBehaviour
{
    [SerializeField] private float size;
    [SerializeField] private float time;
    void Start()
    {
        transform.DOScale(size, time);
    }
}
