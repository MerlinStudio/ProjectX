using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTRotation : MonoBehaviour
{
    [SerializeField] private Vector3 FinalRotation;
    [SerializeField] private Ease ease;

    public float Delay;
    public float Duration;

    void Start()
    {
        Rotation(FinalRotation);
    }


    private void Rotation(Vector3 angle)
    {
        transform.DORotate(angle, Duration, RotateMode.FastBeyond360).SetEase(ease).SetLoops(-1);
    }
}
