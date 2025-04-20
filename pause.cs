using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
  [SerializeField] private GameObject pauseMenu;
  private bool paused = false;
  void Start()
  {
    pauseMenu.SetActive(false);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (paused)
      {
        unpauseGame();
      }
      else
      {
        pauseGame();
      }
    }
  }
  
  public void pauseGame()
  {
    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;
    pauseMenu.SetActive(true);
    Time.timeScale = 0;
    paused = true; 
  }

  public void unpauseGame()
  {
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
    pauseMenu.SetActive(false);
    Time.timeScale = 1; 
    paused = false;
  }

  public void menu()
  {Time.timeScale = 1;
  SceneManager.LoadScene(0);
  }

  public void quitGame()
  {
    Application.Quit();
  }
}
