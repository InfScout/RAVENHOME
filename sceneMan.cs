using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneMan : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void YAY()
    {
        SceneManager.LoadScene(2);
    }
}
