using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabStar : MonoBehaviour
{
    private Animation Animation;
    void Start()
    {
        Animation = transform.GetChild(0).GetComponent<Animation>();
        Animation.Play("TakeStar");
        Invoke("Delay", 1f);
    }

    private void Delay()
    {
        Destroy(gameObject);
    }
}
