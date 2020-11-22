using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance = null;

    [SerializeField] private GameObject Menu;
    void Start()
    {
        if (instance == null) { instance = this; }
        Time.timeScale = 1;
    }

    public void UsedPause(int time, bool state)
    {
        Time.timeScale = time;
        Menu.SetActive(state);
    }
}
