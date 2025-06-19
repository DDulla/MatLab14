using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LoadingPanel : MonoBehaviour
{
    public static LoadingPanel Instance;

    public Transform panelTransform;
    public Vector3 hiddenPosition;
    public Vector3 visiblePosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadSceneWithPanel(string sceneName)
    {
        panelTransform.DOMove(visiblePosition, 0.5f).OnComplete(() =>
        {
            SceneManager.LoadSceneAsync(sceneName);
        });
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        panelTransform.DOMove(hiddenPosition, 0.5f);
    }
}