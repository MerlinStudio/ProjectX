using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public Button Level1, Level2, Level3, Level4;
    void Start()
    {
        Level1.onClick.AddListener(() => LoadingScene.instance.LoadScene(1));
        Level2.onClick.AddListener(() => LoadingScene.instance.LoadScene(2));
        Level3.onClick.AddListener(() => LoadingScene.instance.LoadScene(3));
        Level4.onClick.AddListener(() => LoadingScene.instance.LoadScene(4));
    }
}
