using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject LevelPanel;
    public GameObject PauseMenu;
    public GameObject MainMenu;
    public GameObject RestartPanel;
    public GameObject CompletedMenu;
    public GameObject continueButton;
    public GameController GameController;

    private void Awake()
    {
       CheckForContinue();
    }

    void Start()
    {
        MainMenu.SetActive(true);
        LevelPanel.SetActive(false);
        PauseMenu.SetActive(false);
    }

    public void PauseGame()
    {
        GameController.GamePaused = true;
        LevelPanel.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void ContinueGame()
    {
        LevelPanel.SetActive(true);
        PauseMenu.SetActive(false);
        GameController.GamePaused = false;
    }

    public void OpenMainMenu()
    {
        CheckForContinue();
        LevelPanel.SetActive(false);
        PauseMenu.SetActive(false);
        CompletedMenu.SetActive(false);
        RestartPanel.SetActive(false);
        MainMenu.SetActive(true);
        GameController.StopLevel();
    }

    public void NewGame()
    {
        GameController.StartLevel(0);
        PlayerPrefs.SetInt("Level", 0);
        GameController.currentLevel = 0;
        MainMenu.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void ContinueOrRestart()
    {
        GameController.StartLevel(GameController.currentLevel);
        MainMenu.SetActive(false);
        RestartPanel.SetActive(false);
        CompletedMenu.SetActive(false);
        LevelPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeLevel()
    {
        GameController.LevelCompleted();
        CompletedMenu.SetActive(false);
    }

    void CheckForContinue()
    {
        if (PlayerPrefs.GetInt("Level") > 0)
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }
}
