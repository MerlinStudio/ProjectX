using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healths : MonoBehaviour
{
    public static Healths instance = null;

    [Space]
    public Image[] ImageHealths = new Image[3];
    public Sprite HaveHealth, EmptyHealth;
    private int NumberHealth;

    [Space]
    public GameObject GameOver;

    private MoveChar MoveChar;
    public static bool damage;

    void Start()
    {
        if(instance == null) { instance = this; }
        damage = false;
        MoveChar = GetComponent<MoveChar>();
        NumberHealth = 3;
        PrintHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Damage" && !damage)
        {
            damage = true;
            if (NumberHealth > 0)
            {
                NumberHealth--;
                PrintHealth();
                GetComponent<Animation>().Play("Damage");
                MoveChar.enabled = false;
                StartCoroutine(Delay());
            }
            else
            {
                GameOver.SetActive(true);
                damage = false;
            }
        }
    }

    private void PrintHealth()
    {
        for (int i = 0; i < ImageHealths.Length; i++)
        {
            if (i < NumberHealth) { ImageHealths[i].sprite = HaveHealth; }
            else { ImageHealths[i].sprite = EmptyHealth; }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = SavePosition.SavedPosition;
        MoveChar.enabled = true;
        yield return new WaitForSeconds(1f);
        damage = false;
    }

    public void AddHealth()
    {
        gameObject.transform.position = SavePosition.SavedPosition;
        MoveChar.enabled = true;
        damage = false;
        GameOver.SetActive(false);
    }
}
