using DG.Tweening;
using UnityEngine;

public class Transition : MonoBehaviour
{
    [SerializeField] private Vector2 FinalPosition;
    [SerializeField] private Ease ease;
    [SerializeField] private float Delay;

    public GameObject Char, TransitionCamera,TransitionMask,CharMask;
    private Transform positionCamera, scaleTransitionMask, scaleCharMask;

    void Start()
    {
        scaleCharMask = CharMask.transform;
        scaleTransitionMask = TransitionMask.transform;
        positionCamera = TransitionCamera.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TransitionCamera.transform.position = Char.transform.position;
            TransitionCamera.SetActive(true);

            scaleTransitionMask.transform.localScale = scaleCharMask.transform.localScale;

            Char.SetActive(false);
            Char.transform.position = FinalPosition;

            positionCamera.DOMove(FinalPosition, Delay).SetEase(ease);
            ControllerTime.instance.InterTimeButton(false);
            Invoke("EndMoving", Delay);
        }
    }
    private void EndMoving()
    {
        ControllerTime.instance.InterTimeButton(true);
        TransitionCamera.SetActive(false);
        Char.SetActive(true);
    }
}
