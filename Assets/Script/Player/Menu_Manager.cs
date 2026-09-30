using UnityEngine;

public class Menu_Manager : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneLoader.Instance.ChangeScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
