using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    
    public GameObject pauseCanvas;
    public Button resumeButton;
    public GameObject gameOverCanvas;
    public Button retryButton;

    void Awake()
    {
        if (Instance != null && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void ChangeCanvasStatus(GameObject canvas, Button selectedButton)
    {
        if (pauseCanvas.activeInHierarchy)
        {
            pauseCanvas.SetActive(false);
        }
        else
        {
            pauseCanvas.SetActive(true);
            resumeButton.Select();
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneLoader.Instance.ChangeScene(sceneName);
    }
}
