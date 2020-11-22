using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTMoving : MonoBehaviour
{
    [SerializeField] private Vector2 FinalPosition;
    [SerializeField] private Ease ease;
    private Vector2 startPos , endValue, endValueStar;

    public bool isStar;
    public float DelayPlay;
    public float Delay;
    public float Duration;

    void Start()
    {
        startPos = transform.position;

        if(isStar)
        {
            endValueStar = new Vector2(startPos.x, startPos.y + 0.2f);
            MoveingStar(endValueStar);
        }
        else
        {
            Invoke("DelayPlaing", DelayPlay);
        }

    }

    private void DelayPlaing()
    {
        endValue = FinalPosition;
        Moveing(endValue);
    }


    private void Moveing(Vector2 pos)
    {
        transform.DOMove(pos, Duration).SetEase(ease).OnComplete(()=> Moveing(endValue)).SetDelay(Delay);
        endValue = endValue == FinalPosition ? startPos : FinalPosition;
    }
    private void MoveingStar(Vector2 pos)
    {
        transform.DOMove(pos, Duration).SetEase(ease).OnComplete(() => MoveingStar(endValueStar)).SetDelay(Delay);
        endValueStar = endValueStar == new Vector2(startPos.x, startPos.y + 0.2f) ? startPos : new Vector2(startPos.x, startPos.y + 0.2f);
    }
}
