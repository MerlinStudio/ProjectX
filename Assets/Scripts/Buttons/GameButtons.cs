using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    public Button MenuGameOver, MenuWon,MenuInPause, NextLevel, ShowAd, Pause, BackPause;

    private int indexScene;
    void Start()
    {
        indexScene = SceneManager.GetActiveScene().buildIndex;
          
        MenuGameOver.onClick.AddListener(() => LoadingScene.instance.LoadScene(0));
        MenuWon.onClick.AddListener(() => LoadingScene.instance.LoadScene(0));
        MenuInPause.onClick.AddListener(() => LoadingScene.instance.LoadScene(0));
        NextLevel.onClick.AddListener(() => LoadingScene.instance.LoadScene(indexScene+1));

        ShowAd.onClick.AddListener(() => Healths.instance.AddHealth());
        Pause.onClick.AddListener(() => PauseMenu.instance.UsedPause(0, true));
        BackPause.onClick.AddListener(() => PauseMenu.instance.UsedPause(1, false));
       
    }
}
