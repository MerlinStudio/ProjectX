using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Portal : MonoBehaviour
{
    public static Portal instance = null;

    [SerializeField] private GameObject PrefabPortal;


    void Start()
    {
        if(instance == null) { instance = this; }
    }

    public void PosPortal(BoxCollider2D boxCollider2D, Vector3 transform)
    {
        Instantiate(PrefabPortal, transform, PrefabPortal.transform.rotation);


        boxCollider2D.enabled = false;

        ResPortal.numberPortal--;
        ResPortal.instance.PrintNumberPortal();
    }
}
