using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    public static EndLevel instance = null;
    public GameObject MenuWon , NextButton, AllStars;
    public Text FindStars, Text;
    public static int ResoulteLevel;
    public static int numberStars;
    private int star;

    private void Start()
    {
        if(instance == null) { instance = this; }
        numberStars = AllStars.transform.childCount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") { CheckResoulte(); }
    }
    public void CheckResoulte()
    {
        star = ResStars.Stars;
        int prosStars = star * 100 / numberStars;
        MenuWon.SetActive(true);
        FindStars.text = string.Format("Вы собрали {0:0}% звезд", prosStars.ToString());
        if (star == numberStars) { PrintResoulte(3, "Perfect", true); }

        else if (star >= numberStars / 4 * 3) { PrintResoulte(2, "Excellent", true); }

        else if (star >= numberStars / 4 * 2) { PrintResoulte(1, "Good", true); }

        else { PrintResoulte(0, "Bad", false); }
    }

    private void PrintResoulte(int resoulteLevel, string text, bool active)
    {
        NextButton.SetActive(active);
        ResoulteLevel = resoulteLevel;
        Text.text = text;
    }
}
