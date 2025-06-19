using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void LoadGame()
    {
        LoadingPanel.Instance.LoadSceneWithPanel("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}