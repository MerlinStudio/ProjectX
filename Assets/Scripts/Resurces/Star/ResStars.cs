using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResStars : MonoBehaviour
{
    [SerializeField] private GameObject[] ProgressStars;
    [SerializeField] private GameObject prefabStar;
    [SerializeField] private Image FillAmount;

    public static int Stars;
    void Start()
    {
        Stars = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            Stars++;
            FillAmount.fillAmount += 1f / EndLevel.numberStars;
            Instantiate(prefabStar, prefabStar.transform.position, prefabStar.transform.rotation);

            if (Stars >= EndLevel.numberStars / 4 * 2)
            {
                ProgressStars[0].SetActive(true);
            }
            if (Stars >= EndLevel.numberStars / 4 * 3)
            {
                ProgressStars[1].SetActive(true);
            }
            if (Stars == EndLevel.numberStars)
            {
                ProgressStars[2].SetActive(true);
            }
        }
    }
}
